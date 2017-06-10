using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nethaxide
{
	/// <summary>
	/// Canvas is a helper class for <see cref="Layer"/>. It helps to draw borders, lines, etc.
	/// 
	/// A Canvas must be bind with a <see cref="Layer"/>.
	/// </summary>
	class Canvas
	{
		public Canvas(int x, int y, int w, int h, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
		{
			_layer = new Layer(x, y, w, h, fg, bg);
			_top = 0;
			_left = 0;
			_width = w;
			_height = h;
			_foreground = fg;
			_background = bg;
		}
		
		public Canvas(Layer layer)
		{
			_layer = layer;
			_top = 0;
			_left = 0;
			_width = layer.Width;
			_height = layer.Height;
			_foreground = ConsoleColor.White;
			_background = ConsoleColor.Black;
		}

		/// <summary>
		/// Writes a string on the canvas.
		/// 
		/// If the string is too long to be put in a single (1) line, a line feed would be 
		/// inserted.
		/// </summary>
		/// <param name="x">X coordinate.</param>
		/// <param name="y">Y coordinate.</param>
		/// <param name="str">The string.</param>
		public void Write(int x, int y, string str)
		{
			//_layer.Write(y, x, str, _foreground, _background);
			x = _left;
			y = _top;
			foreach (char c in str)
			{
				if (x + _left == _width)
				{
					x = _left;
					y++;
					if (y + _top == _height)
					{
						// overflown!
						y = _top;
					}
				}
				_layer.DrawAt(y, x, c, _foreground, _background);
				x++;
			}
		}

		public void Line(int x1, int y1, int x2, int y2, char ends = '*', char body = '*')
		{
			_layer.DrawAt(y1, x1, ends, _foreground, _background);
			_layer.DrawAt(y2, x2, ends, _foreground, _background);

		}

		public void Circle(int x, int y, int radius)
		{

		}

		public void SetBorder(BorderType type)
		{
			if (type  == BorderType.NONE)
			{
				_width = _layer.Width;
				_height = _layer.Height;
				_left = 0;
				_top = 0;
				return;
			}
			
			if((type & BorderType.LEFT) == BorderType.LEFT)
			{
				_left = 1;
				_width--;
				Line(0, 0, 0, _layer.Height - 1, '+', '|');
			}

			if((type & BorderType.TOP) == BorderType.TOP)
			{
				_top = 1;
				_height--;
				Line(0, 0, _layer.Width - 1, 0, '+', '-');
			}

			if((type & BorderType.RIGHT) == BorderType.RIGHT)
			{
				_width--;
				Line(_layer.Width - 1, 0, _layer.Width - 1, _layer.Height - 1, '+', '|');
			}

			if((type & BorderType.BOTTOM) == BorderType.BOTTOM)
			{
				_height--;
				Line(0, _layer.Height - 1, _layer.Width - 1, _layer.Height - 1, '+', '-');
			}
		}

		public void Register(Screen screen)
		{
			screen.RegisterLayer(_layer);
		}

		public void Remove(Screen screen)
		{
			screen.RemoveLayer(_layer);
		}

		public Layer Layer
		{
			get
			{
				return _layer;
			}

			set
			{
				_layer = value;
			}
		}

		private Layer _layer;
		private int _left, _top;
		private int _width, _height;
		private ConsoleColor _foreground, _background;
	}
}
