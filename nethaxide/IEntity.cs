using System;
namespace nethaxide
{
	/// <summary>
	/// Entity is the basic moving stuff.
	/// </summary>
	[Serializable]
	public abstract class IEntity
	{
		protected IEntity()
		{
			_name = string.Empty;
			_chunk = null;
			_x = -1;
			_y = -1;
			_texture = new Texture('E', ConsoleColor.Black, ConsoleColor.Red);
			_inv = null;
		}

		public Texture Texture
		{
			get
			{
				return _texture;
			}

			set
			{
				_texture = value;
			}
		}

		Inventory Inventory 
		{ 
			get
			{
				return _inv;
			}

			set
			{
				_inv = value;
			}
		
		}

		protected string _name;
		protected Chunk _chunk;
		protected int _x, _y;
		protected Texture _texture;
		protected Inventory _inv;
	}
}
