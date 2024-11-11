using FwksLabs.Libs.Core.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace FwksLabs.Libs.Infra.Postgres.HealthChecks;

public sealed class PostgresHealthCheck(
    ILogger<PostgresHealthCheck> logger,
    string connString) : BaseHealthCheck<PostgresHealthCheck>(logger), IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) =>
        CheckHealthAsync(
            context,
            async () =>
            {
                using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync(cancellationToken);
            },
            cancellationToken);
}