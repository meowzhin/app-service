namespace FwksLabs.Libs.Postgres.Abstractions.Repositories;

public interface ITransacionalRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
