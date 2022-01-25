using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bancoex.core.Interfaces;
using bancoex.persistencia.Data;
using bancoex.core.Entities;
using System.Linq.Expressions;

namespace bancoex.persistencia.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, IEntity
	{
        private readonly BanCtx _ctx;

        private DbSet<T> _entity;

		public Repository(BanCtx context)
		{
            _ctx = context;
            _entity = context.Set<T>();
		}

        public async Task<int> Create(T entity)
        {
            _entity.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await _entity.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return false;
            _entity.Remove(entity);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> query)
        {
            return await _entity.Where(query).ToListAsync();
        }

        public async Task<T> Read(int id)
        {
            return await _entity.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> Update(int id, T entity)
        {
            var update = await _entity.FirstOrDefaultAsync(e => e.Id == id);
            if (update == null) return 0;
            update = entity;
            _entity.Update(update);
            return update.Id;
        }
    }
}

