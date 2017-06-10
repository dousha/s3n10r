using System;
namespace nethaxide
{
	/// <summary>
	/// Chunk describes the Geometry of a scene, which is composed 
	/// with <see cref="ITile"/>.
	/// 
	/// Chunk is serializable by calling .Serialize().
	/// </summary>
	public class Chunk
	{
		public Chunk(int width, int height, string json)
		{
			_width = width;
			_height = height;

		}

		public string Serialize()
		{
			return string.Empty;
		}

		int _width, _height;
	}
}
