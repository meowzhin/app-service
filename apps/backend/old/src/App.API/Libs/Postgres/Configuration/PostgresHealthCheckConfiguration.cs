using FwksLabs.Libs.Core.Configuration;
using FwksLabs.Libs.Infra.Postgres.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.Infra.Postgres.Configuration;

public static class PostgresHealthCheckConfiguration
{
    public static IHealthChecksBuilder AddPostgresHealthCheck(this IHealthChecksBuilder builder, string name, string connString, bool critical) =>
        builder
            .AddCustomHealthCheck(name, sp => 
                new PostgresHealthCheck(sp.GetRequiredService<ILogger<PostgresHealthCheck>>(), connString), critical);
}