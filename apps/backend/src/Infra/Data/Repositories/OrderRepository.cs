using FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;
using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Resources.Orders;
using FwksLabs.ResumeService.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.ResumeService.Infra.Data.Repositories;

public sealed class OrderRepository(DatabaseContext dbContext) : TransactionalRepository<int, OrderEntity>(dbContext), IOrderRepository
{
    public override Task<List<OrderEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        DbSet.Include(static x => x.Customer).ToListAsync(cancellationToken);

    public Task<List<OrderEntity>> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default) =>
        DbSet.Include(x => x.Customer).Where(x => x.CustomerId == customerId).ToListAsync(cancellationToken);
}