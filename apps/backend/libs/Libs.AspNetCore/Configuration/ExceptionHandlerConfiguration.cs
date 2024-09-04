using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using FwksLabs.Libs.AspNetCore.Middlewares;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class ExceptionHandlerConfiguration
{
    public static IServiceCollection AddUnexpectedExceptionMiddleware(this IServiceCollection services) =>
        services
            .AddScoped<UnexpectedExceptionMiddleware>();

    public static IServiceCollection AddExceptionHandlerMiddleware<T>(this IServiceCollection services)
        where T : class =>
            services
                .AddScoped<T>();

    public static IApplicationBuilder UseUnexpectedExceptionMiddleware(this IApplicationBuilder builder) =>
        builder
            .UseMiddleware<UnexpectedExceptionMiddleware>();

    public static IApplicationBuilder UseExceptionHandlerMiddleware<T>(this IApplicationBuilder builder)
        where T : class =>
            builder
                .UseMiddleware<T>();
}
