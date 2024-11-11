using FwksLabs.Libs.Core.Types;
using FwksLabs.Libs.Postgres.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.Libs.Postgres.Repositories;

public abstract class TransactionalRepository<TEntity>(DbContext dbContext) : BaseRepository<TEntity>(dbContext), ITransacionalRepository
        where TEntity : BaseEntity
{
    protected readonly DbContext dbContext = dbContext;

    public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}