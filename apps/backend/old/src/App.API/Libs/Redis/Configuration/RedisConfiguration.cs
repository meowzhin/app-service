using FwksLabs.Libs.Core.Abstractions.Services;
using FwksLabs.Libs.Infra.Redis.Services;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FwksLabs.Libs.Infra.Redis.Configuration;

public static class RedisConfiguration
{
    public static IServiceCollection AddRedis(this IServiceCollection services, string connectionString) =>
        services
            .AddSingleton(new Lazy<IConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString)))
            .AddScoped(sp => sp.GetRequiredService<Lazy<IConnectionMultiplexer>>().Value!.GetDatabase())
            .AddScoped<IRedisService, RedisService>();
}