using System;
namespace nethaxide
{
	/// <summary>
	/// Entity is the basic moving stuff.
	/// </summary>
	public abstract class IEntity
	{
		protected IEntity()
		{
			_texture = new Texture('E', ConsoleColor.White, ConsoleColor.Black);
			_inv = new Inventory();
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

		protected Chunk _chunk;
		protected int _x, _y;
		protected Texture _texture;
		protected Inventory _inv;
	}
}
