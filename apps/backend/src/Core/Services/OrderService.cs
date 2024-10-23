using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Abstractions.Services;
using FwksLabs.AppService.Core.Abstractions.Services.Common;
using FwksLabs.AppService.Core.Extensions;
using FwksLabs.AppService.Core.Resources.Orders;
using FwksLabs.AppService.Core.Resources.Orders.Inputs;
using FwksLabs.AppService.Core.Resources.Orders.Outputs;
using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Outputs;

namespace FwksLabs.AppService.Core.Services;

public sealed class OrderService(
    IValidatorService validator,
    IOrderRepository repository) : IOrderService
{
    public async Task<IdOutput?> AddAsync(OrderInput input, CancellationToken cancellationToken)
    {
        if (!await validator.ValidateInputAsync(input, cancellationToken))
            return default;

        var ett = input.ToEntity();

        await repository.AddAsync(ett, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);

        return new(ett.EncodeId());
    }

    public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (!await ValidateIdAsync(id, cancellationToken))
            return;

        await repository.DeleteByIdAsync(id.Decode(), cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<PageOutput<OrderOutput>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);

        return entities.Select(x => x.ToOutput()).ToPagedOutput();
    }

    public async Task<PageOutput<OrderOutput>> GetByCustomerIdAsync(string customerId, CancellationToken cancellationToken)
    {
        var entities = await repository.GetByCustomerIdAsync(customerId.Decode(), cancellationToken);

        return entities.Select(x => x.ToOutput()).ToPagedOutput();
    }

    private Task<bool> ValidateIdAsync(string id, CancellationToken cancellationToken) =>
        validator.ValidateIdAsync<OrderEntity, IOrderRepository>(id, cancellationToken);
}
