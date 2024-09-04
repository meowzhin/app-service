using System.Linq.Expressions;
using FwksLabs.Libs.Core.Abstractions.Repositories;
using FwksLabs.Libs.Core.Entities;

namespace FwksLabs.AppService.Core.Abstractions.Services.Common;

public interface IValidatorService
{
    Task<bool> ValidateInputAsync<TInstance>(TInstance instance, CancellationToken cancellationToken = default)
        where TInstance : class;

    Task<bool> ValidateIdAsync<TEntity, TRepository>(string id, CancellationToken cancellationToken = default)
        where TEntity : Entity<int>
        where TRepository : IBaseRepository<int, TEntity>;

    Task<bool> ValidateByAsync<TEntity, TRepository>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : Entity<int>
        where TRepository : IBaseRepository<int, TEntity>;
}
