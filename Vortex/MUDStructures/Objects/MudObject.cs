using System;
using Vortex.Communication;

namespace Vortex.MUDStructures.Objects
{
	public abstract class MudObject
	{
		public int Vnum;
		public ColorString ShortDescription;
		public ColorString LongDescription;
		public string Name;

		public MudObject()
		{
		}
	}
}
