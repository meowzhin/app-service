using FluentValidation;
using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;

namespace FwksLabs.Libs.AspNetCore.Extensions;

public static class ValidatorExtensions
{
    public static async Task<bool> ValidateAsync<TInstance>(this IValidator<TInstance> validator, TInstance instance, IRequestContext context, CancellationToken cancellationToken = default)
        where TInstance : class
    {
        var result = await validator.ValidateAsync(instance, cancellationToken);

        if (result.IsValid)
            return true;

        context.AddBadRequest().AddValidationErrors(result.Errors.Select(static x => x.ErrorMessage));

        return false;
    }
}