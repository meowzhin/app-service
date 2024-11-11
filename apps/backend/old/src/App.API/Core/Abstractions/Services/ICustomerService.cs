using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Resources.Customers.Inputs;
using FwksLabs.AppService.Core.Resources.Customers.Outputs;
using FwksLabs.Libs.Core.Outputs;

namespace FwksLabs.AppService.Core.Abstractions.Services;

public interface ICustomerService : IService
{
    Task<PageOutput<CustomerOutput>> GetAllAsync(CancellationToken cancellationToken);
    Task<CustomerOutput?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IdOutput?> AddAsync(CustomerInput input, CancellationToken cancellationToken);
    Task UpdateAsync(CustomerInput input, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}