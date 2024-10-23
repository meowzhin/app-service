using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.Libs.Infra.Redis.Configuration;

public static class RedisConfiguration
{
    public static IServiceCollection AddDistributedCache2(this IServiceCollection services, string appName, string connectionString) =>
        services
            .AddStackExchangeRedisCache(x =>
            {
                x.InstanceName = appName;
                x.Configuration = connectionString;
            });
}