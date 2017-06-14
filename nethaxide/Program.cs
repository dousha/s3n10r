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
			// [DBG]
			Console.Out.WriteLine("Multiple connection test...");
			Server server = new Server();

			Client client = new Client("dousha");
			Client client2 = new Client("innsd");
			Client client3 = new Client("Qinglem");

			Console.WriteLine("Done. Press any key to exit.");
			Console.ReadKey(true);
		}
	}
}
