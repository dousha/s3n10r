using System;

namespace nethaxide
{
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts 
		/// and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			Screen screen = new Screen();

			screen.Clear();
			screen.Print("Nethaxide");
			Layer layer = screen.CreateLayer(1, 1, 20, 20);
			layer.DrawAt(0, 0, '!', ConsoleColor.White, ConsoleColor.Blue);
			layer.Write(0, 1, "Here it is!", ConsoleColor.White, ConsoleColor.Cyan);
			Layer anotherLayer = screen.CreateLayer(2, 2, 15, 2);
			anotherLayer.Write(0, 0, "Hi there!", ConsoleColor.Blue, ConsoleColor.Gray);
			screen.Render();
		}
	}
}
