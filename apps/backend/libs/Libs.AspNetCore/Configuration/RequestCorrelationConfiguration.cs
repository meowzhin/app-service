using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using FwksLab.Libs.AspNetCore.Middlewares;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class RequestCorrelationConfiguration
{
    public static IServiceCollection AddRequestCorrelationMiddleware(this IServiceCollection services)
    {
        return services
            .AddScoped<RequestCorrelationMiddleware>();
    }

    public static IApplicationBuilder UseRequestCorrelationMiddleware(this IApplicationBuilder builder)
    {
        return builder
            .UseMiddleware<RequestCorrelationMiddleware>();
    }
}
