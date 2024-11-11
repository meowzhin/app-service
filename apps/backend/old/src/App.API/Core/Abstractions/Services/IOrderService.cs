using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Resources.Orders.Inputs;
using FwksLabs.AppService.Core.Resources.Orders.Outputs;
using FwksLabs.Libs.Core.Outputs;

namespace FwksLabs.AppService.Core.Abstractions.Services;

public interface IOrderService : IService
{
    Task<PageOutput<OrderOutput>> GetAllAsync(CancellationToken cancellationToken);
    Task<PageOutput<OrderOutput>> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken);
    Task<IdOutput?> AddAsync(OrderInput input, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
