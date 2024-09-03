using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using FwksLab.Libs.AspNetCore.Middlewares;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class ExceptionHandlerConfiguration
{
    public static IServiceCollection AddUnexpectedExceptionMiddleware(this IServiceCollection services)
    {
        return services
            .AddScoped<UnexpectedExceptionMiddleware>();
    }

    public static IServiceCollection AddExceptionHandlerMiddleware<T>(this IServiceCollection services)
        where T : class
    {
        return services
            .AddScoped<T>();
    }

    public static IApplicationBuilder UseUnexpectedExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder
            .UseMiddleware<UnexpectedExceptionMiddleware>();
    }

    public static IApplicationBuilder UseExceptionHandlerMiddleware<T>(this IApplicationBuilder builder)
        where T : class
    {
        return builder
            .UseMiddleware<T>();
    }
}
