using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Resources.Orders;
using FwksLabs.Libs.Core.Abstractions.Repositories;

namespace FwksLabs.AppService.Core.Abstractions.Repositories;

public interface IOrderRepository : IBaseRepository<int, OrderEntity>, ITransacionalRepository, IService
{
    Task<List<OrderEntity>> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);
}