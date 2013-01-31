using System;
using Vortex.MUDStructures.Characters;
using System.Linq;

namespace Vortex.Commands.PlayerCommands
{
	[Command("who")]
	public class Who : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			callingPlayer.SendToCharacter("Online Players\n\r");
			callingPlayer.SendToCharacter("==============\n\r");

			int playerCount = 0;
			foreach (var ch in Character.CharacterList.Where(c => c is PlayerCharacter)) {
				callingPlayer.SendToCharacter(String.Format(" {0}\n\r", ch.Name));
				playerCount ++;
			}

			callingPlayer.SendToCharacter(String.Format("\n\r{0} total players online\n\r", playerCount));
			return true;
		}
	}
}
