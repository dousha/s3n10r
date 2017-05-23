using System;
using Newtonsoft.Json.Schema;
namespace nethaxide
{
	/// <summary>
	/// Texture. Literally 'Text'ure. Get it?
	/// </summary>
	public struct Texture
	{
		public Texture(char t, ConsoleColor fg, ConsoleColor bg)
		{
			_text = t;
			_fg = fg;
			_bg = bg;
		}

		public char Text
		{
			get
			{
				return _text;
			}

			set
			{
				_text = value;
			}
		}

		public ConsoleColor Foreground
		{
			get
			{
				return _fg;
			}
		}

		public ConsoleColor Background
		{
			get
			{
				return _bg;
			}
		}

		private char _text;
		private ConsoleColor _fg, _bg;
	}
}
