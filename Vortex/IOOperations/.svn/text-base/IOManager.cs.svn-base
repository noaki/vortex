using System;
using Vortex.Commands;
using Vortex.MUDStructures.Rooms;

namespace Vortex.IOOperations
{
	public static class IOManager
	{
		static IOManager()
		{
		}

		public static void InitilizeGameData()
		{
			// here we start reading in required game files, for now we just simulate it
			Console.Write("Loading Commands... ");
			var commandsLoaded = CommandHandler.LoadCommands();
			Console.Write("DONE! {0} commands loaded!{1}", commandsLoaded, Environment.NewLine);

			Console.Write("Reading in game data...");
			InitilizeRooms();
			Console.Write(" DONE!" + Environment.NewLine);
		}

		private static void InitilizeRooms()
		{
			Room room1 = new Room(1);
		}
	}
}
