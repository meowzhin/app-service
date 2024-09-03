using FwksLab.AppService.Core.Abstractions.Repositories;
using FwksLab.AppService.Core.Entities;
using FwksLab.AppService.Infra.Data.Context;
using FwksLab.Libs.Infra.EntityFrameworkCore.Repositories;

namespace FwksLab.AppService.Infra.Data.Repositories;

public sealed class CustomerRepository(DatabaseContext databaseContext) : BaseRepository<Guid, CustomerEntity>(databaseContext), ICustomerRepository
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return databaseContext.SaveChangesAsync(cancellationToken);
    }
}
