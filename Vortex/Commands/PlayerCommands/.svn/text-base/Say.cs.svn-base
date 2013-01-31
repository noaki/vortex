using System;
using Vortex.MUDStructures.Characters;
using Vortex.Communication;

namespace Vortex.Commands.PlayerCommands
{
	[Command("say")]
	public class Say : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			if (parameters.Length == 0) {
				callingPlayer.SendToCharacter("What do you want to say?\n\r");
				return false;
			}

			ColorString toPlayer = new ColorString(String.Format("You say, \"{0}\"\n\r", parameters));
			ColorString toOthers = new ColorString(String.Format("{0} says, \"{1}\"\n\r", callingPlayer.Name, parameters));

			callingPlayer.SendToCharacter(toPlayer);

			// for each character in the room
			foreach (var ch in callingPlayer.InRoom.PlayerCharactersInRoom) {
				// we need to say what needs to be said
				if(ch != callingPlayer) {
					ch.SendToCharacter(toOthers);
				}
			}

			return true;
		}
	}
}

