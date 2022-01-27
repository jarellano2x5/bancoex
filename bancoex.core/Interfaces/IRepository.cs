using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using bancoex.core.Entities;

namespace bancoex.core.Interfaces
{
	public interface IRepository<T> where T : IEntity
	{
		Task<int> Create(T entity);
		Task<T> Read(int id);
		Task<int> Update(int id, T entity);
		Task<bool> Delete(T entity);

		Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> query);
	}
}

