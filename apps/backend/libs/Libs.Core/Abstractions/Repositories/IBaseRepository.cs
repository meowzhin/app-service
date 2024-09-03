using System.Linq.Expressions;
using FwksLab.Libs.Core.Entities;

namespace FwksLab.Libs.Core.Abstractions.Repositories;

public interface IBaseRepository<TPrimaryKey, TEntity>
    where TPrimaryKey : struct
    where TEntity : Entity<TPrimaryKey>
{
    ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken = default);

    ValueTask<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAndTrackAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
