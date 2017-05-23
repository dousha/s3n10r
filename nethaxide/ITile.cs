using System;
namespace nethaxide
{
	/// <summary>
	/// Tile is the basic <see cref="Chunk"/> component.
	/// 
	/// A tile could either be a <see cref="Space"/>, 
	/// a <see cref="Machine"/> or a <see cref="Portal"/>.
	/// </summary>
	public interface ITile
	{
		Texture Texture { get; }
	}	
}
