using System;
namespace nethaxide
{
	public class Machine : ITile
	{
		public Machine()
		{
			_texture = new Texture('o', ConsoleColor.Green, ConsoleColor.Black);
		}

		public Texture Texture
		{
			get
			{
				return _texture;
			}
		}

		public virtual void OnStepOn(object sender, EventArgs e)
		{
			
		}

		private Texture _texture;
	}
}
