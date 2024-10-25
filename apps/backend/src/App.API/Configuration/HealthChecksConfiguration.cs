using FwksLabs.Libs.AspNetCore.Configuration;
using FwksLabs.ResumeService.App.Api.Configuration;
using FwksLabs.ResumeService.Core.Configuration.Settings;

namespace FwksLabs.ResumeService.App.Api.Configuration;

public static class HealthChecksConfiguration
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddHealthChecks()
            //.AddPostgresHealthCheck("postgres", appSettings.Persistence.Postgres.Build(), true)
            //.AddRedisHealthCheck("redis", appSettings.Persistence.Redis.Build(), false)
            .AddInternalServiceHealthCheck("fwks-customers", "https://localhost:5001", false);

        return services;
    }
}