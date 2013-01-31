using System;
using Vortex.MUDStructures.Characters;
using Vortex.MUDStructures.Rooms;

namespace Vortex.Commands.PlayerCommands
{
	[Command("look")]
	public class Look : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			Room inRoom = callingPlayer.InRoom;
			callingPlayer.SendToCharacter(String.Format("[{0} = {1}]\n\r", inRoom._title.RawString, inRoom.Vnum));
			callingPlayer.SendToCharacter(inRoom._description + "\n\r");

			foreach (var ch in inRoom.CharactersInRoom) {
				if (ch != callingPlayer) {
					callingPlayer.SendToCharacter(String.Format("{0} is here.\n\r", ch.Name));
					if (ch is PlayerCharacter && parameters != "quiet") {
						((PlayerCharacter)ch).SendToCharacter(String.Format("{0} takes a look around.\n\r", callingPlayer.Name));
					}
				}
			}
			return true;
		}
	}
}
