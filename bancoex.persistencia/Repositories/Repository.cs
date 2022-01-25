using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bancoex.core.Interfaces;

namespace bancoex.persistencia.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		public Repository()
		{
		}

        public Task<int> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Filter(Func<T, bool> query)
        {
            throw new NotImplementedException();
        }

        public Task<T> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}

