using System;
using System.Collections.Generic;
namespace nethaxide
{
	/// <summary>
	/// Screen is a Console manipulating class. It also helps on 
	/// rendering scenes.
	/// </summary>
	public class Screen
	{
		public Screen()
		{
			_col = 0;
			_row = 0;
			_width = 80;
			_height = 24;
			Console.SetWindowSize(80, 24);
			_layers = new LinkedList<Layer>();
		}

		public Screen(int w, int h)
		{
			_col = 0;
			_row = 0;
			this._width = w;
			this._height = h;
			Console.SetWindowSize(w, h);
			_layers = new LinkedList<Layer>();
		}

		public void Clear()
		{
			Console.Clear();
		}

		public void Print(string s)
		{
			Console.Out.Write(s);
		}

		/// <summary>
		/// Sets the cursor.
		/// If any parameter excess the limitation of the screen,
		/// by default it would be set to the maxium possible 
		/// position.
		/// 
		/// This method is discouraged to use. Use <see cref="T:SetPen"/> 
		/// instead.
		/// </summary>
		/// <param name="col">Column.</param>
		/// <param name="row">Row.</param>
		public void SetCursor(int col, int row)
		{
			_row = row;
			_col = col;
			Console.SetCursorPosition(col, row);
		}

		/// <summary>
		/// Sets the pen. The pen postion is relative to the focused layer.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void SetPen(int x, int y)
		{
			_row = y + _curLayer.Y;
			_col = x + _curLayer.X;
		}

		/// <summary>
		/// Focus the specified layer.
		/// </summary>
		/// <returns>The focus.</returns>
		/// <param name="layer">Layer.</param>
		public void Focus(Layer layer)
		{
			_curLayer = _layers.Contains(layer) ? _curLayer : layer;
		}

		/// <summary>
		/// Creates a layer.
		/// </summary>
		/// <returns>The layer object.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="w">The width.</param>
		/// <param name="h">The height.</param>
		public Layer CreateLayer(int x, int y, int w, int h)
		{
			Layer l = new Layer(
				x > _col ? _col : x,
				y > _row ? _row : y,
				w > _width ? _width : w, 
				h > _height ? _height : h
			);
			return l;
		}

		public void RegisterLayer(Layer layer)
		{
			if (layer == null) return;
			_layers.AddLast(layer);
		}

		public void RemoveLayer(Layer layer)
		{
			_layers.Remove(layer);
		}

		/// <summary>
		/// Render the screen.
		/// </summary>
		public void Render()
		{
			foreach (Layer layer in _layers)
			{
				SetCursor(layer.X, layer.Y);
				for (int i = 0; i < layer.Height; i++)
				{
					for (int j = 0; j < layer.Width; j++)
					{
						if (_col + j == _width) break;
						Console.SetCursorPosition(_col + j, _row + i);
						Console.BackgroundColor = 
							layer.GetTextureAt(_row + i, _col + j).Background;
						Console.ForegroundColor =
							layer.GetTextureAt(_row + i, _col + j).Foreground;
						Console.Write(layer.GetCharAt(_row + i, _col + j));
					}
				}
			}
		}

		int Width
		{
			get
			{
				return _width;
			}
		}

		int Height
		{
			get
			{
				return _height;
			}
		}

		private int _row, _col;
		private int _width, _height;
		private LinkedList<Layer> _layers;
		private Layer _curLayer;
	}
}
