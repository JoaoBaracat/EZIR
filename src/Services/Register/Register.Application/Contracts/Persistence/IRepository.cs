using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Register.Applicatioin.Contracts.Persistence
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<IReadOnlyList<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}