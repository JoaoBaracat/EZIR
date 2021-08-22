using Microsoft.EntityFrameworkCore;
using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using Register.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Register.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly RegisterContext _dbContext;

        public Repository(RegisterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            query = query.AsNoTracking();

            if (predicate != null) query = query.Where(predicate);

            return await query.ToListAsync();
        }
    }
}