using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.Libs.Infra.Postgres.Configuration;

public static class PostgresConfiguration
{
    public static IServiceCollection AddEntityFrameworkPostgres<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        return services
            .AddDbContext<TDbContext>(x => x.UseNpgsql(connectionString));
    }
}