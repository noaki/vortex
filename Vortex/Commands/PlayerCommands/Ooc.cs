using System;
using Vortex.MUDStructures.Characters;
using Vortex.Communication;

namespace Vortex.Commands.PlayerCommands
{
	[Command("ooc")]
	public class Ooc : BasicCommand
	{
		public override bool Execute(PlayerCharacter callingPlayer, string parameters)
		{
			if (parameters.Length == 0) {
				callingPlayer.SendToCharacter("What do you want to say?\n\r");
				return false;
			}
		
			callingPlayer.SendToCharacter(String.Format("{{gYou OOC \"{{x{0}{{g\"{{x\n\r", parameters));

			ColorString toOthers = new ColorString(String.Format("{{g{0} OOC \"{{x{1}{{g\"{{x\n\r", callingPlayer.Name, parameters));

			foreach (Character ch in Character.CharacterList) {
				if (ch is PlayerCharacter) {
					PlayerCharacter player = ch as PlayerCharacter;
					if (player != callingPlayer) {
						player.SendToCharacter(toOthers);
					}
				}
			}

			return true;
		}
	}
}
