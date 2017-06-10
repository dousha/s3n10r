using System;
using System.Collections.Generic;
namespace nethaxide
{
	/// <summary>
	/// Layer is a piece of content on the screen.
	/// 
	/// Layer can be 'focused' by the screen. By default, 
	/// the drawing would be done in the layer rather directly on the 
	/// console.
	/// </summary>
	public class Layer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:nethaxide.Layer"/> class.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="w">The width.</param>
		/// <param name="h">The height.</param>
		public Layer(int x, int y, int w, int h, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
		{
			_buffer = new Texture[w * h];
			for (int i = 0; i < w * h; i++)
			{
				_buffer[i].Text = ' ';
				_buffer[i].Foreground = fg;
				_buffer[i].Background = bg;
			}
			_x = x;
			_y = y;
			_width = w;
			_height = h;
		}

		/// <summary>
		/// Draws at row, column with specified Texture.
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="col">Column.</param>
		/// <param name="t">Texture.</param>
		public void DrawAt(int row, int col, Texture t)
		{
			_buffer[row * _width + col] = t;
		}

		/// <summary>
		/// Draws at row and column with character, foreground and background.
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="col">Col.</param>
		/// <param name="c">Char.</param>
		/// <param name="fg">Foreground.</param>
		/// <param name="bg">Background.</param>
		public void DrawAt(int row, 
						   int col, 
						   char c, 
						   ConsoleColor fg, 
						   ConsoleColor bg)
		{
			_buffer[row * _width + col].Text = c;
			_buffer[row * _width + col].Foreground = fg;
			_buffer[row * _width + col].Background = bg;
		}

		/// <summary>
		/// Gets the texture at row and column.
		/// </summary>
		/// <returns>The <see cref="!:Texture"/>.</returns>
		/// <param name="row">Row.</param>
		/// <param name="col">Column.</param>
		public Texture GetTextureAt(int row, int col)
		{
			return _buffer[row * _width + col];
		}

		/// <summary>
		/// Gets the char at row and column.
		/// </summary>
		/// <returns>The <see cref="T:System.Char"/>.</returns>
		/// <param name="row">Row.</param>
		/// <param name="col">Column.</param>
		public char GetCharAt(int row, int col)
		{
			return _buffer[row * _width + col].Text;
		}

		public int X
		{
			get
			{
				return _x;
			}
		}

		public int Y
		{
			get
			{
				return _y;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
		}

		private int _x, _y;
		private int _width, _height;
		private Texture[] _buffer;
	}
}
