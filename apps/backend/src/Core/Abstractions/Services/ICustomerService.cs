using FwksLab.AppService.Core.Inputs.Customers;
using FwksLab.AppService.Core.Outputs.Common;
using FwksLab.AppService.Core.Outputs.Customers;

namespace FwksLab.AppService.Core.Abstractions.Services;

public interface ICustomerService
{
    Task<IReadOnlyCollection<CustomerOutput>> GetAsync(CancellationToken cancellationToken = default);
    Task<ResourceOutput?> AddAsync(CustomerInput input, CancellationToken cancellationToken = default);
    Task PatchAsync(Guid id, CustomerInput input, CancellationToken cancellationToken = default);
}
