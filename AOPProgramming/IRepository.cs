using System.Collections.Generic;

namespace AOPProgramming
{
	internal interface IRepository<T>
	{
		void Add(T book);

		IList<T> GetList();

		bool Remove(int id);
	}
}