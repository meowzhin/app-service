using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Abstractions.Services;
using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Extensions;
using FwksLabs.AppService.Core.Resources.Customers;
using FwksLabs.AppService.Core.Resources.Customers.Inputs;
using FwksLabs.AppService.Core.Resources.Customers.Outputs;
using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Outputs;

namespace FwksLabs.AppService.Core.Services;

public sealed class CustomerService(
    IValidatorService validator,
    ICustomerRepository repository) : ICustomerService
{
    public async Task<IdOutput?> AddAsync(CustomerInput input, CancellationToken cancellationToken)
    {
        if (!await validator.ValidateInputAsync(input, cancellationToken))
            return default;

        var ett = input.ToEntity();

        await repository.AddAsync(ett, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);

        return new(ett.EncodeId());
    }

    public async Task UpdateAsync(CustomerInput input, CancellationToken cancellationToken)
    {
        if (!await validator.ValidateInputAsync(input, cancellationToken))
            return;

        var ett = await repository.GetByIdAsync(input.Id!.Decode(), cancellationToken);

        ett!.Patch(input);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (!await ValidateIdAsync(id, cancellationToken))
            return;

        await repository.DeleteByIdAsync(id.Decode(), cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<PageOutput<CustomerOutput>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);

        return entities.Select(x => x.ToOutput()).ToPagedOutput();
    }

    public async Task<CustomerOutput?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (!await ValidateIdAsync(id, cancellationToken))
            return default;

        var entities = await repository.GetByIdAsync(id.Decode(), cancellationToken);

        return entities!.ToOutput();
    }

    private Task<bool> ValidateIdAsync(string id, CancellationToken cancellationToken) =>
        validator.ValidateIdAsync<CustomerEntity, ICustomerRepository>(id, cancellationToken);
}
