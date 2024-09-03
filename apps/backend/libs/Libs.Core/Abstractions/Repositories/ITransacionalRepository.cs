namespace FwksLab.Libs.Core.Abstractions.Repositories;

public interface ITransacionalRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
