using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using FwksLabs.Libs.AspNetCore.Middlewares;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class RequestCorrelationConfiguration
{
    public static IServiceCollection AddRequestCorrelationMiddleware(this IServiceCollection services) =>
        services
            .AddScoped<RequestCorrelationMiddleware>();

    public static IApplicationBuilder UseRequestCorrelationMiddleware(this IApplicationBuilder builder) =>
        builder
            .UseMiddleware<RequestCorrelationMiddleware>();
}
