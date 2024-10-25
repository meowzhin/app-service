using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;
using FwksLabs.ResumeService.Core.Resources.Orders;

namespace FwksLabs.ResumeService.Core.Abstractions.Repositories;

public interface IOrderRepository : IBaseRepository<int, OrderEntity>, ITransacionalRepository, IService
{
    Task<List<OrderEntity>> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);
}