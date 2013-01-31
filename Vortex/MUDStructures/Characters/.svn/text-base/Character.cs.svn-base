using System;
using System.Collections.Generic;
using Vortex.MUDStructures.Rooms;

namespace Vortex.MUDStructures.Characters
{
	/// <summary>
	/// Base class for both player and non-player characters
	/// </summary>
	public class Character
	{
		/// <summary>
		/// Gets or sets the character's name.
		/// </summary>
		/// <value>
		/// The character's name.
		/// </value>
		public string Name { get; set; }

		public Room InRoom { get; set; }

		public Character()
		{
		}

		#region Global character list access
		protected static LinkedList<Character> _characterList = new LinkedList<Character>();

		static public LinkedList<Character> CharacterList {
			get { return _characterList; }
		}

		static public void AddCharacterToGame(Character ch)
		{
			_characterList.AddLast(ch);
		}

		static public void RemoveCharacterFromGame(Character ch)
		{
			_characterList.Remove(ch);
		}
		#endregion
	}
}

