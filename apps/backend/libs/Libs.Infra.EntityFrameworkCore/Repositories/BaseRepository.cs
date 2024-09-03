using System.Linq.Expressions;
using FwksLab.Libs.Core.Abstractions.Repositories;
using FwksLab.Libs.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FwksLab.Libs.Infra.EntityFrameworkCore.Repositories;

public abstract class BaseRepository<TPrimaryKey, TEntity>(DbContext dbContext) : IBaseRepository<TPrimaryKey, TEntity>
    where TPrimaryKey : struct
    where TEntity : Entity<TPrimaryKey>
{
    internal readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public async ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await DbSet.AddAsync(entity, cancellationToken);
    public ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException("Relational repository doesn't implement manual update. Use tracker instead.");
    public async Task DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FindAsync([id], cancellationToken);

        if (entity == null)
            return;

        DbSet.Remove(entity);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await DbSet.AsNoTracking().ToListAsync(cancellationToken);
    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        await DbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    public async Task<IEnumerable<TEntity>> GetAndTrackAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        await DbSet.Where(predicate).ToListAsync(cancellationToken);
    public ValueTask<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default) =>
        DbSet.FindAsync([id], cancellationToken);
}
