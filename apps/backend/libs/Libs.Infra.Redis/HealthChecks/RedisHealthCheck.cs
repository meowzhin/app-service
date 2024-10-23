using FwksLabs.Libs.Core.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace FwksLabs.Libs.Infra.Redis.HealthChecks;

public sealed class RedisHealthCheck(
    ILogger<RedisHealthCheck> logger,
    string connectionString) : BaseHealthCheck<RedisHealthCheck>(logger), IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) =>
        CheckHealthAsync(context, async () => _ = await ConnectionMultiplexer.Connect(connectionString).GetDatabase().PingAsync(), cancellationToken);
}
