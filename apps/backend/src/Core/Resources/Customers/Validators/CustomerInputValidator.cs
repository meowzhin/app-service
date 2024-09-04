using FluentValidation;
using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Resources.Common.Inputs;
using FwksLabs.AppService.Core.Resources.Customers.Inputs;
using FwksLabs.Libs.Core.Security.Extensions;

namespace FwksLabs.AppService.Core.Resources.Customers.Validators;

public sealed class CustomerInputValidator : AbstractValidator<CustomerInput>
{
    public CustomerInputValidator(
        IValidator<PhoneNumberInput> phoneValidator,
        ICustomerRepository customerRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync((id, token) => customerRepository.ExistsAsync(x => x.Id == id!.Decode(), token))
            .WithMessage("Customer id '{PropertyValue}' not found.")
            .When(x => x.Id is not null);

        RuleFor(x => x.Name.First).NotEmpty();

        RuleFor(x => x.Name.Last).NotEmpty();

        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Phone).SetValidator(phoneValidator);
    }
}
