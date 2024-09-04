using FluentValidation;
using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Resources.Orders.Inputs;
using FwksLabs.Libs.Core.Security.Extensions;

namespace FwksLabs.AppService.Core.Resources.Orders.Validators;

public sealed class OrderInputValidator : AbstractValidator<OrderInput>
{
    public OrderInputValidator(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync((id, token) => orderRepository.ExistsAsync(x => x.Id == id!.Decode(), token))
            .WithMessage("Order id '{PropertyValue}' not found.")
            .When(x => x.Id is not null);

        RuleFor(x => x.Amount).GreaterThan(0);

        RuleFor(x => x.CustomerId)
            .MustAsync((id, token) => customerRepository.ExistsAsync(x => x.Id == id!.Decode(), token))
            .WithMessage("Customer id '{PropertyValue}' not found.")
            .When(x => x.Id is not null);
    }
}