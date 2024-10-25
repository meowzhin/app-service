using System.Linq.Expressions;
using FluentValidation;
using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using FwksLabs.Libs.AspNetCore.Extensions;
using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;

namespace FwksLabs.ResumeService.App.Api.Services.Common;

public sealed class ValidatorService(
    IRequestContext requestContext,
    IServiceProvider serviceProvider) 
    : IValidatorService
{
    public Task<bool> ValidateInputAsync<TInstance>(TInstance instance, CancellationToken cancellationToken = default)
         where TInstance : class =>
             serviceProvider
                 .GetRequiredService<IValidator<TInstance>>()
                 .ValidateAsync(instance, requestContext, cancellationToken);

    public async Task<bool> ValidateIdAsync<TEntity, TRepository>(string id, CancellationToken cancellationToken = default)
        where TEntity : Entity<int>
        where TRepository : IBaseRepository<int, TEntity>
    {
        var repository = serviceProvider.GetRequiredService<TRepository>();

        if (await repository.ExistsAsync(x => x.Id == id.Decode(), cancellationToken))
            return true;

        requestContext.AddNotFound("Id not found", $"Id '{id}' was not found.");

        return false;
    }

    public async Task<bool> ValidateByAsync<TEntity, TRepository>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : Entity<int>
        where TRepository : IBaseRepository<int, TEntity>
    {
        var repository = serviceProvider.GetRequiredService<TRepository>();

        if (await repository.ExistsAsync(predicate, cancellationToken))
            return true;

        requestContext.AddNotFound("Not found", $"Record not found.");

        return false;
    }
}