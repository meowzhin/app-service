using FluentValidation;
using FwksLabs.AppService.Core.Resources.Common.Inputs;

namespace FwksLabs.AppService.Core.Resources.Common.Validators;

public sealed class PhoneNumberInputValidator : AbstractValidator<PhoneNumberInput>
{
    public PhoneNumberInputValidator()
    {
        RuleFor(x => x.CountryCode)
            .Must(x => x.StartsWith('+'))
            .WithMessage("Country code must start with '+' indicating country.");

        RuleFor(x => x.Number)
            .Matches("^[0-9]+$")
            .WithMessage("The Number must contain only numeric characters.");
    }
}
