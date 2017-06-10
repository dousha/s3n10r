using System;
namespace nethaxide
{
	/// <summary>
	/// Space is a Tile where player could stand on.
	/// </summary>
	public class Space : ITile
	{
		public Space()
		{
			_texture = new Texture(' ', ConsoleColor.Black, ConsoleColor.Black);
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
