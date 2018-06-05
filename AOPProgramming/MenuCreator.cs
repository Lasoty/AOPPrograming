using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPProgramming
{
	class MenuCreator
	{
		public void ShowMenu()
		{
			Console.WriteLine("1. Dodaj nową pozycję do biblioteki.");
			Console.WriteLine("2. Wyświetl wszystkie pozycje biblioteki.");
			Console.WriteLine("3. Usuń wybraną pozycję z biblioteki.");
			Console.Write("Twój wybór: ");
		}

		public void ShowTitle()
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine("Programowanie z wykorzystaniem Interceptorów");
			Console.ResetColor();
		}
	}
}
