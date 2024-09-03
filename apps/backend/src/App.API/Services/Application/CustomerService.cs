using FwksLab.AppService.App.Api.Extensions;
using FwksLab.AppService.Core.Abstractions.Repositories;
using FwksLab.AppService.Core.Abstractions.Services;
using FwksLab.AppService.Core.Inputs.Customers;
using FwksLab.AppService.Core.Outputs.Common;
using FwksLab.AppService.Core.Outputs.Customers;
using FwksLab.Libs.AspNetCore.Abstractions.Contexts;

namespace FwksLab.AppService.App.Api.Services.Application;

public sealed class CustomerService(
    IRequestContext requestContext,
    ICustomerRepository repository) : ICustomerService
{
    public async Task<IReadOnlyCollection<CustomerOutput>> GetAsync(CancellationToken cancellationToken = default)
    {
        return (await repository.GetAllAsync(cancellationToken)).Select(CustomerOutput.Transform).ToList();
    }

    public async Task<ResourceOutput?> AddAsync(CustomerInput input, CancellationToken cancellationToken = default)
    {
        if (input.Address?.Country != "BR")
        {
            requestContext
                .AddBadRequest()
                .AddValidationErrors("Invalid country.");

            return default;
        }

        var entity = input.Transform();

        await repository.AddAsync(entity, cancellationToken);

        _ = await repository.SaveChangesAsync(cancellationToken);

        return new(entity.Id);
    }

    public async Task PatchAsync(Guid id, CustomerInput input, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);

        if (entity == default)
        {
            requestContext
                .AddNotFound("Customer Not Found", "We couldn't find a customer with this id.");

            return;
        }

        input.Patch(entity);

        _ = await repository.SaveChangesAsync(cancellationToken);
    }
}
