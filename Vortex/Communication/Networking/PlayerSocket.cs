using System;
using System.Net.Sockets;
using System.Text;
using Vortex.MUDStructures.Characters;

namespace Vortex.Communication.Networking
{
	public class PlayerSocket
	{
		private Socket _socket;
		private byte[] _receivedByte = new byte[1];
		private string _inputBuffer;
		private string _receivedBytesString;
		private object _inputLock = new object();
		private StringBuilder _outputBuffer = new StringBuilder();

		public PlayerCharacter OwningPlayer { get; set; }

		public PlayerSocket(Socket sock)
		{
			_socket = sock;
			// Start receiving data from the socket - retrieve one byte at a time
			_socket.BeginReceive(_receivedByte, 0, 1, SocketFlags.None, new AsyncCallback(OnReceive), null);
		}

		public void SendToPlayer(string msg)
		{
			_outputBuffer.Append(msg);
		}

		public void FlushOutput()
		{
			if (_socket != null && _socket.Connected && _outputBuffer.Length > 0) {
				byte[] bytes = ASCIIEncoding.ASCII.GetBytes(_outputBuffer.ToString());
				_socket.Send(bytes);
				_outputBuffer.Length = 0;
			}
		}

		private void OnReceive(IAsyncResult result)
		{
			try {
				if (_socket.EndReceive(result) == 0) {
					// Player has disconnected
					Console.WriteLine(String.Format("Player {0} has disconnected.", this.OwningPlayer.Name));
					return;
				}
			} catch (SocketException ex) {
				if (ex.SocketErrorCode == SocketError.ConnectionReset) {
					// client disconnected
					Console.WriteLine(String.Format("Player {0} has remotely disconnected.", this.OwningPlayer.Name));
					_socket = null;
					return;
				} else {
					throw ex;
				}
			}

			// if the received char is a newline or end of string then copy the recieved buffer to the input buffer
			char thisChar = ASCIIEncoding.ASCII.GetChars(_receivedByte)[0];
			if (thisChar == '\0' || thisChar == '\r' || thisChar == '\n') {
				if (_receivedBytesString.Length > 0) {
					lock (_inputLock) {
						_inputBuffer = _receivedBytesString;
					}
				}
				_receivedBytesString = "";
			} else {
				_receivedBytesString += thisChar;
			}

			// Continue to receive
			_socket.BeginReceive(_receivedByte, 0, 1, SocketFlags.None, new AsyncCallback(OnReceive), null);
		}

		public bool HasInput {
			get { return _inputBuffer != null; }
		}

		public bool HasOutput {
			get { return _outputBuffer.Length > 0; }
		}

		public string GetPlayerInput()
		{
			string result;
			lock (_inputLock) {
				result = _inputBuffer;
				_inputBuffer = null;
			}
			return result;
		}

		public void Disconnect()
		{
			_socket.Disconnect(false);
		}
	}
}
