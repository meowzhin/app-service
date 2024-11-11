using System.Linq.Expressions;
using FwksLabs.Libs.Core.Types;
using FwksLabs.Libs.Postgres.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.Libs.Postgres.Repositories;

public abstract class BaseRepository<TEntity>(DbContext dbContext) : IBaseRepository<int, TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await DbSet.AddAsync(entity, cancellationToken);

    public virtual ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException("Relational repository doesn't implement manual update. Use tracker instead.");

    public virtual async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FindAsync([id], cancellationToken);

        if (entity == null)
            return;

        DbSet.Remove(entity);
    }

    public virtual async Task DeleteByReferenceAsync(Guid reference, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FirstOrDefaultAsync(x => x.ReferenceId == reference, cancellationToken);

        if (entity == null)
            return;

        DbSet.Remove(entity);
    }

    public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        DbSet.ToListAsync(cancellationToken);

    public virtual Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.Where(predicate).ToListAsync(cancellationToken);

    public virtual ValueTask<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        DbSet.FindAsync([id], cancellationToken);

    public virtual Task<TEntity?> GetByReferenceAsync(Guid reference, CancellationToken cancellationToken = default) =>
        DbSet.FirstOrDefaultAsync(x => x.ReferenceId == reference, cancellationToken);

    public virtual Task<TEntity?> SearchOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.FirstOrDefaultAsync(predicate, cancellationToken);

    public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        DbSet.AnyAsync(predicate, cancellationToken);
}
