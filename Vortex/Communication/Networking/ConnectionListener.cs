using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Net;

namespace Vortex.Communication.Networking
{
	public class ConnectionListener
	{
		private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		private int _port;
		private Queue<Socket> _acceptedSockets = new Queue<Socket>();

		public ConnectionListener(int port)
		{
			_port = port;
			_socket.Bind(new IPEndPoint(IPAddress.Any, _port));
		}

		public void StartListening()
		{
			// Start listening for a connection on the socket, reserve 4 spots in the pending connection queue
			_socket.Listen(4);
			// Assign a callback to handle when a new connection is made
			_socket.BeginAccept(new AsyncCallback(OnClientConnect), null);
		}

		public void StopListening()
		{
		}

		private void OnClientConnect(IAsyncResult asyn)
		{
			// TODO: Place IP banning logic here
			Console.WriteLine("DEBUG: CONNECTION DETECTED");

			// Place the newly accepted socket into the queue
			lock (_acceptedSockets) {
				_acceptedSockets.Enqueue(_socket.EndAccept(asyn));
			}

			// Start another accept call on the socket
			_socket.BeginAccept(new AsyncCallback(OnClientConnect), null);
		}

		public List<Socket> AcceptConnections()
		{
			List<Socket> newConnections = new List<Socket>();

			lock (_acceptedSockets) {
				while (_acceptedSockets.Count > 0) {
					newConnections.Add(_acceptedSockets.Dequeue());
				}
				_acceptedSockets.Clear();
			}

			return newConnections;
		}
	}
}
