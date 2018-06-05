using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPProgramming
{
	internal class BookRepository : IRepository<Book>
	{
		public List<Book> Books { get; set; }

		public void Add(Book book)
		{
			LogManager.GetCurrentClassLogger().Debug($"Invokation Add({book})");
			if (Books == null) Books = new List<Book>();
			if (Books.Any())
				book.Id = Books.Max(b => b.Id) + 1;
			Books.Add(book);
			Console.WriteLine($"Dodano {book}.");
			LogManager.GetCurrentClassLogger().Debug($"End Invokation Add.");
		}

		public IList<Book> GetList()
		{
			LogManager.GetCurrentClassLogger().Debug($"Invokation GetList()");
			return Books;
		}

		public bool Remove(int id)
		{
			LogManager.GetCurrentClassLogger().Debug($"Invokation Remove({id})");
			try
			{
				Books.Remove(Books.First(b => b.Id == id));
				LogManager.GetCurrentClassLogger().Debug($"End Invokation Remove with value {false}.");
				return true;
			}
			catch (Exception ex)
			{
				LogManager.GetLogger("ErrorLogger").Error(ex);
			}
			LogManager.GetCurrentClassLogger().Debug($"End Invokation Remove with value {false}.");
			return false;
		}
	}
}
