using System;

namespace Vortex.MUDStructures.Exceptions
{
	public class VnumInUseException : Exception
	{
		public VnumInUseException(string msg) : base(msg)
		{
		}
	}
}

