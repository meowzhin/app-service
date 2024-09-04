using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.Libs.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;

public abstract class TransactionalRepository<TPrimaryKey, TEntity>(DbContext dbContext) : BaseRepository<TPrimaryKey, TEntity>(dbContext), ITransacionalRepository
        where TPrimaryKey : struct
        where TEntity : Entity<TPrimaryKey>
{
    protected readonly DbContext dbContext = dbContext;

    public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}