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
			Canvas canvas = new Canvas(1, 1, 15, 15, ConsoleColor.White, ConsoleColor.Blue);
			canvas.SetBorder(BorderType.LEFT | BorderType.TOP);
			canvas.Write(0, 0, "Hi");

			canvas.Register(screen);
			screen.Render();
		}
	}
}
