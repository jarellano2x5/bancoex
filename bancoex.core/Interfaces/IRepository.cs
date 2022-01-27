using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bancoex.core.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task<int> Create(T entity);
		Task<T> Read(int id);
		Task<int> Update(int id, T entity);
		Task<bool> Delete(T entity);

		Task<IEnumerable<T>> Filter(Func<T, bool> query);
	}
}

