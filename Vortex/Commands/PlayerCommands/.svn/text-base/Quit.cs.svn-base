using System;
using Vortex.MUDStructures.Characters;

namespace Vortex.Commands.PlayerCommands
{
	[Command("quit")]
	public class Quit : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			callingPlayer.SendToCharacter("Saving and exiting, goodbye!");
			callingPlayer.Disconnect();
			return true;
		}
	}
}
