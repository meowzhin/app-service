using System.Linq.Expressions;
using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.Libs.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;

public abstract class BaseRepository<TPrimaryKey, TEntity>(DbContext dbContext) : IBaseRepository<TPrimaryKey, TEntity>
    where TPrimaryKey : struct
    where TEntity : Entity<TPrimaryKey>
{
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await DbSet.AddAsync(entity, cancellationToken);

    public virtual ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException("Relational repository doesn't implement manual update. Use tracker instead.");

    public virtual async Task DeleteByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FindAsync([id], cancellationToken);

        if (entity == null)
            return;

        DbSet.Remove(entity);
    }

    public virtual async Task DeleteByUniqueIdAsync(Guid uniqueId, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.UniqueId == uniqueId, cancellationToken);

        if (entity == null)
            return;

        DbSet.Remove(entity);
    }

    public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        DbSet.ToListAsync(cancellationToken);

    public virtual Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.Where(predicate).ToListAsync(cancellationToken);

    public virtual ValueTask<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default) =>
        DbSet.FindAsync([id], cancellationToken);

    public virtual Task<TEntity?> GetByUniqueIdAsync(Guid uniqueId, CancellationToken cancellationToken = default) =>
        DbSet.FirstOrDefaultAsync(x => x.UniqueId == uniqueId, cancellationToken);

    public virtual Task<TEntity?> SearchOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.FirstOrDefaultAsync(predicate, cancellationToken);

    public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.AnyAsync(predicate, cancellationToken);
}
