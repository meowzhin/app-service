using System.Linq.Expressions;
using FwksLabs.Libs.Core.Entities;

namespace FwksLabs.Libs.Core.Abstractions.Repositories;

public interface IBaseRepository<TPrimaryKey, TEntity>
    where TPrimaryKey : struct
    where TEntity : Entity<TPrimaryKey>
{
    ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
    Task DeleteByUniqueIdAsync(Guid uniqueId, CancellationToken cancellationToken = default);

    ValueTask<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByUniqueIdAsync(Guid uniqueId, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity?> SearchOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}