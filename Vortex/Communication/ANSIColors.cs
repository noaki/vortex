using System;
using System.Collections.Generic;

namespace Vortex.Communication
{
	public static class ANSIColors
	{
		static private char _escapeCharacter = Convert.ToChar(27);
		static private Dictionary<string, string> _colorCodes = new Dictionary<string, string>();

		static public Dictionary<string, string> ColorCodes { get { return _colorCodes; } }

		static public char EscapeCharacter { get { return _escapeCharacter; } }

		static ANSIColors()
		{
			_colorCodes.Add("{{", "{");
			
			_colorCodes.Add("{r", _escapeCharacter + "[0;31m");
			_colorCodes.Add("{1", _escapeCharacter + "[0;31m");
			_colorCodes.Add("{R", _escapeCharacter + "[1;31m");
			_colorCodes.Add("{!", _escapeCharacter + "[1;31m");
			
			_colorCodes.Add("{g", _escapeCharacter + "[0;32m");
			_colorCodes.Add("{2", _escapeCharacter + "[0;32m");
			_colorCodes.Add("{G", _escapeCharacter + "[1;32m");
			_colorCodes.Add("{@", _escapeCharacter + "[1;32m");
			
			_colorCodes.Add("{y", _escapeCharacter + "[0;33m");
			_colorCodes.Add("{3", _escapeCharacter + "[0;33m");
			_colorCodes.Add("{Y", _escapeCharacter + "[1;33m");
			_colorCodes.Add("{#", _escapeCharacter + "[1;33m");
			
			_colorCodes.Add("{b", _escapeCharacter + "[0;34m");
			_colorCodes.Add("{4", _escapeCharacter + "[0;34m");
			_colorCodes.Add("{B", _escapeCharacter + "[1;34m");
			_colorCodes.Add("{$", _escapeCharacter + "[1;34m");
			
			_colorCodes.Add("{m", _escapeCharacter + "[0;35m");
			_colorCodes.Add("{5", _escapeCharacter + "[0;35m");
			_colorCodes.Add("{M", _escapeCharacter + "[1;35m");
			_colorCodes.Add("{%", _escapeCharacter + "[1;35m");
			
			_colorCodes.Add("{c", _escapeCharacter + "[0;36m");
			_colorCodes.Add("{6", _escapeCharacter + "[0;36m");
			_colorCodes.Add("{C", _escapeCharacter + "[1;36m");
			_colorCodes.Add("{^", _escapeCharacter + "[1;36m");
			
			_colorCodes.Add("{w", _escapeCharacter + "[0;37m");
			_colorCodes.Add("{7", _escapeCharacter + "[0;37m");
			_colorCodes.Add("{W", _escapeCharacter + "[1;37m");
			_colorCodes.Add("{&", _escapeCharacter + "[1;37m");
			
			_colorCodes.Add("{D", _escapeCharacter + "[1;30m");
			_colorCodes.Add("{8", _escapeCharacter + "[1;30m");
			
			//_colorCodes.Add("{*", "");
			
			_colorCodes.Add("{x", _escapeCharacter + "[0m");
			_colorCodes.Add("{0", _escapeCharacter + "[0m");
		}
	}
}

