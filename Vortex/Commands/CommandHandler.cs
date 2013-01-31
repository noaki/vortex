using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Vortex.Commands
{
	public static class CommandHandler
	{
		static SortedDictionary<string, BasicCommand> _commandDictionary = new SortedDictionary<string, BasicCommand>();

		static CommandHandler()
		{
		}

		/// <summary>
		/// Loads valid commands that have been added to the code.  This uses reflection to find and add valid commands.
		/// </summary>
		/// <returns>
		/// The number of commands loaded.
		/// </returns>
		public static int LoadCommands()
		{
			// repopulate the command dictionary, we don't want to load it twice
			_commandDictionary = new SortedDictionary<string, BasicCommand>();

			// below the the entire loop wrapped up in a single linq query
			// this is pointless really and not readable, but was fun to write
			// Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BasicCommand))).Select(t => (BasicCommand)Activator.CreateInstance(t)).Where( c => c.CommandAttributes != null).ToList().ForEach(c => _commandDictionary.Add(c.CommandAttributes.Name, c));

			// First get all of the types included in the assembly
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {
				// Check to see if the type inherits from BasicCommand
				if (type.IsSubclassOf(typeof(BasicCommand))) {
					// Use some fancy reflection code to create a class of this BasicCommand subclass
					BasicCommand newCommand = (BasicCommand)Activator.CreateInstance(type);

					if (newCommand.CommandAttributes != null) {
						// We only consider this a valid command if it was decorated with a CommandAttribute
						_commandDictionary.Add(newCommand.CommandAttributes.Name, newCommand);
					}
				}
			}

			// this just lets up know how many commands were loaded by this function
			return _commandDictionary.Count;
		}
		
		public static List<string> GetValidCommands()
		{
			return _commandDictionary.Keys.ToList();
		}

		public static BasicCommand GetMatchingCommand(string str)
		{
			// go go LINQ, all we are doing here is parseing each command's key (the name) and comparing it with the str to match
			// we take all the results and return the first one
			return _commandDictionary.Where(kvp => kvp.Key.StartsWith(str, true, null)).Select(kvp=>kvp.Value).FirstOrDefault();
		}
	}
}
