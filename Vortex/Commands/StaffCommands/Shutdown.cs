using System;
using Vortex.MUDStructures.Characters;

namespace Vortex.Commands.StaffCommands
{
	[Command("shutdown")] // this uses the CommandAttribute class located in BasicCommand.cs
	public class Shutdown : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			foreach (Character ch in Character.CharacterList) {
				if( ch is PlayerCharacter) {
					((PlayerCharacter)ch).SendToCharacter(String.Format("[System] Vortex MUD has been shutdown by {0}.", callingPlayer.Name));
				}
			}

			MUDServer.Running = false;
			return true;
		}
	}
}
