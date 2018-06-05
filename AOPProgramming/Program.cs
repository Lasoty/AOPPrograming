using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPProgramming
{
	class Program
	{
		static void Main(string[] args)
		{
			IoC.SetupContainer();
			char t;
			do
			{
				Console.Clear();
				MenuCreator menu = IoC.Container.Resolve<MenuCreator>();
				menu.ShowTitle();
				menu.ShowMenu();

				if (int.TryParse(Console.ReadLine(), out int selection))
				{
					ExecuteSelection(selection);
				}

				t = ShowPrompt();
			} while (t != 'n');
		}

		private static void ExecuteSelection(int selection)
		{
			IRepository<Book> bookRepo = IoC.Container.Resolve<IRepository<Book>>();
			switch (selection)
			{
				case 1:
					Console.WriteLine("Wprowadź dane książki:");
					Book book = new Book();
					Console.Write(" Autor: ");
					book.Author = Console.ReadLine();
					Console.Write(" Tytuł: ");
					book.Title = Console.ReadLine();
					bookRepo.Add(book);
					break;
				case 2:
					Console.WriteLine("Lista książek: ");
					foreach (Book item in bookRepo.GetList())
					{
						Console.WriteLine(item);
					}
					break;
				case 3:
					Console.Write("Podaj Id książki do usunięcia: ");
					if (int.TryParse(Console.ReadLine(), out int id))
					{
						if (bookRepo.Remove(id))
							Console.WriteLine("Książka usunięta.");
						else
							Console.WriteLine("Książka nie została usunięta.");
					}
					break;
				default:
					Console.WriteLine("Wybór nieprawidłowy.");
					break;
			}
		}

		private static char ShowPrompt()
		{
			Console.Write("Jeszcze raz? [T|n]");
			return Console.ReadKey().KeyChar;
		}
	}
}
