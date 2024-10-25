using FwksLabs.Libs.Core.Outputs;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;
using FwksLabs.ResumeService.Core.Resources.Orders.Inputs;
using FwksLabs.ResumeService.Core.Resources.Orders.Outputs;

namespace FwksLabs.ResumeService.Core.Abstractions.Services;

public interface IOrderService : IService
{
    Task<PageOutput<OrderOutput>> GetAllAsync(CancellationToken cancellationToken);
    Task<PageOutput<OrderOutput>> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken);
    Task<IdOutput?> AddAsync(OrderInput input, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
