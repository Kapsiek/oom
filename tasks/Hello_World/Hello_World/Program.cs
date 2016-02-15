using System;

namespace Hello_World
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string name;
			Console.WriteLine ("Hello! Whats your name?\n");
			name = Console.ReadLine();
			Console.WriteLine("\nHello {0} \n", name);
			Console.ReadLine ();
		}
	}
}
