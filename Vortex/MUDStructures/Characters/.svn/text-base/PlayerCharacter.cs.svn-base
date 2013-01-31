using System;
using Vortex.Communication.Networking;
using Vortex.Communication;

namespace Vortex.MUDStructures.Characters
{
	public enum TempPlayerNames { Hank, Fred, Tom, Jenny, Robin, Nathan, Tanya, Robert, Daisy };

	public enum PlayerGameState
	{
		NoGameState,
		LostConnection,
		Connecting,
		RetrievingName,
		RetrievingPassword,
		CreateNewNameConfirmation,
		CreateNewPassword,
		VerifyNewPassword,
		MOTD,
		Playing
	}

	public class PlayerCharacter : Character
	{
		protected PlayerSocket _socket = null;

		public PlayerGameState GameState { get; set; }
		public bool HasColorEnabled { get; set; }

		public bool HasInput { get { return _socket.HasInput; } }
		public bool HasOutput { get { return _socket.HasOutput; } }

		public PlayerCharacter(PlayerSocket socket)
		{
			_socket = socket;
			_socket.OwningPlayer = this;
			this.GameState = PlayerGameState.Connecting;

			this.Name = ((TempPlayerNames)(MUDServer.rand.Next(8))).ToString();
			this.HasColorEnabled = true;

			SendToCharacter(String.Format("Welcome, you have been assigned the name {0} during your stay!\n\r", this.Name));

			if (this.HasColorEnabled) {
				SendToCharacter(new ColorString("Color {{ is {RON{x!\n\r"));
			} else {
				SendToCharacter(new ColorString("Color {{ is {ROFF{x!\n\r"));
			}
		}

		public void Disconnect()
		{
			_socket.Disconnect();
			this.GameState = PlayerGameState.LostConnection;
		}

		public void SendToCharacter(ColorString message)
		{
			if (this.HasColorEnabled) {
				WriteToSocket(message.ColoredString);
			} else {
				WriteToSocket(message.NoColorString);
			}
		}

		public void SendToCharacter(string message)
		{
			SendToCharacter(new ColorString(message));
		}

		public void WriteToSocket(string message)
		{
			_socket.SendToPlayer(message);
		}
		
		public string GetInput()
		{
			return _socket.GetPlayerInput();
		}

		public void FlushOutput()
		{
			_socket.FlushOutput();
		}
	}
}

