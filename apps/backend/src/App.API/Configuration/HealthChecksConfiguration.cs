using FwksLabs.AppService.Core.Configuration.Settings;
using FwksLabs.Libs.Infra.Postgres.Configuration;
using FwksLabs.Libs.Infra.Redis.Configuration;
using FwksLabs.Libs.AspNetCore.Configuration;

namespace FwksLabs.AppService.App.Api.Configuration;

public static class HealthChecksConfiguration
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddHealthChecks()
            .AddPostgresHealthCheck("postgres", appSettings.Persistence.Postgres.Build(), true)
            .AddRedisHealthCheck("redis", appSettings.Persistence.Redis.Build(), false)
            .AddInternalServiceHealthCheck("fwks-customers", "https://localhost:5001", false);

        return services;
    }
}