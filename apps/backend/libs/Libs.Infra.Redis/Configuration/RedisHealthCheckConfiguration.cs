using FwksLabs.Libs.Core.Configuration;
using FwksLabs.Libs.Infra.Redis.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.Infra.Redis.Configuration;

public static class RedisHealthCheckConfiguration
{
    public static IHealthChecksBuilder AddRedisHealthCheck(this IHealthChecksBuilder builder, string name, string connectionString, bool critical) =>
        builder
            .AddCustomHealthCheck(name, sp => 
                new RedisHealthCheck(sp.GetRequiredService<ILogger<RedisHealthCheck>>(), connectionString), critical);
}