using System;
namespace nethaxide
{
	public class Portal : ITile
	{
		public Portal()
		{
			_texture = new Texture('@', ConsoleColor.White, ConsoleColor.Black);
		}

		public Texture Texture
		{
			get
			{
				return _texture;
			}
		}

		private Texture _texture;
	}
}
