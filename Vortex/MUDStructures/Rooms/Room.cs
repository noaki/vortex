using System;
using System.Linq;
using System.Collections.Generic;
using Vortex.Communication;
using Vortex.MUDStructures.Characters;

namespace Vortex.MUDStructures.Rooms
{
	public class Room
	{
		protected static Dictionary<int, Room> _roomList = new Dictionary<int, Room>();

		public static Room GetRoom(int vnum)
		{
			if (_roomList.ContainsKey(vnum)) {
				return _roomList[vnum];
			}
			return null;
		}

		protected int _vnum;
		public ColorString _title;
		public ColorString _description;

		public int Vnum { get { return _vnum; } }

		protected List<Character> _charsInRoom = new List<Character>();

		// TODO: The plan with this will be to allow ANY VALID (not sure what will not be allowed at this point) to be an exit name
		public Dictionary<string, RoomExit> _exits = new Dictionary<string, Room>();

		public List<Character> CharactersInRoom { get { return _charsInRoom; } }

		public Room(int vnum)
		{
			if (_roomList.ContainsKey(vnum)) {
				throw new Exceptions.VnumInUseException("Room vnum already in use!");
			}

			_vnum = Vnum;
			_title = new ColorString("New room");
			_description = new ColorString("This is a new room that has not been initilized yet.");

			_roomList.Add(vnum, this);
		}

		public IEnumerable<PlayerCharacter> PlayerCharactersInRoom {
			get {
				foreach (Character ch in _charsInRoom) {
					if (ch is PlayerCharacter) {
						yield return (PlayerCharacter)ch;
					}
				}
			}
		}

		public void AddCharacterToRoom(Character ch)
		{
			this.CharactersInRoom.Add(ch);
			ch.InRoom = this;
		}

		public void RemoveCharacterFromRoom(Character ch)
		{
			this.CharactersInRoom.Remove(ch);
			ch.InRoom = null;
		}
	}
}

