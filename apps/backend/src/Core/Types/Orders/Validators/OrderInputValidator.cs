using FluentValidation;
using FwksLabs.Libs.Core.Extensions;
using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Resources.Orders.Inputs;

namespace FwksLabs.ResumeService.Core.Resources.Orders.Validators;

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