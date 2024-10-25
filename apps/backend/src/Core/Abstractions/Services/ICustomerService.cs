using FwksLabs.Libs.Core.Outputs;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;
using FwksLabs.ResumeService.Core.Resources.Customers.Inputs;
using FwksLabs.ResumeService.Core.Resources.Customers.Outputs;

namespace FwksLabs.ResumeService.Core.Abstractions.Services;

public interface ICustomerService : IService
{
    Task<PageOutput<CustomerOutput>> GetAllAsync(CancellationToken cancellationToken);
    Task<CustomerOutput?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IdOutput?> AddAsync(CustomerInput input, CancellationToken cancellationToken);
    Task UpdateAsync(CustomerInput input, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}