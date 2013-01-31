using System;

namespace Vortex.MUDStructures.Rooms
{
	public class RoomExit
	{
		// TODO: Add things like doors or actions?
		public Room ToRoom { get; set;}
		public string Direction { get; set;}

		public RoomExit()
		{
		}
	}
}

