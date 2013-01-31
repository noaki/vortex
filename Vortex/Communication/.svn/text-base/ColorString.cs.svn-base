using System;
using System.Text;
using Vortex;

namespace Vortex.Communication
{
	// TODO: This needs to store just the raw string until some finalize method is called to commit the changes.
	public class ColorString
	{
		private string _rawString;
		private string _ansiString;
		private string _noColorString;

		public string RawString {
			get { return _rawString; }
		}

		public string ColoredString {
			get { return _ansiString; }
		}
		
		public string NoColorString {
			get { return _noColorString; }
		}
		
		public static ColorString operator+(ColorString cString, String str)
		{
			return new ColorString(cString.ColoredString + str);
		}
		
		public static ColorString operator +(String str, ColorString cString)
		{
			return new ColorString(str + cString.ColoredString);
		}

		public ColorString(string str)
		{
			_rawString = str;

			StringBuilder ansiBuilder = new StringBuilder();
			StringBuilder noColorBuilder = new StringBuilder();
			
			int j = 0;
			for (int i = str.IndexOf('{'); i >= 0 && i < str.Length; i = str.IndexOf('{', i)) {
				// place the characters up to this point into the string
				string substr = str.Substring(j, i - j);
				ansiBuilder.Append(substr);
				noColorBuilder.Append(substr);
				
				// try to find a match for this escape code
				string colorCode = str.Substring(i, 2);
				if (ANSIColors.ColorCodes.ContainsKey(colorCode)) {
					ansiBuilder.Append(ANSIColors.ColorCodes[colorCode]);
				} else if (colorCode == "{*") {
					ansiBuilder.Append(String.Format("{0}[{1};3{2}m", ANSIColors.EscapeCharacter, MUDServer.rand.Next(2), MUDServer.rand.Next(8) + 1));
				}
				
				i += 2;
				// set j to i
				j = i;
			}
			
			// add the remaining characters
			ansiBuilder.Append(str.Substring(j, str.Length - j) + ANSIColors.ColorCodes["{x"]);
			noColorBuilder.Append(str.Substring(j, str.Length - j));
			
			_ansiString = ansiBuilder.ToString();
			_noColorString = noColorBuilder.ToString();
		}
	}
}

