using System.Net.Mime;
using FwksLabs.Libs.AspNetCore.Extensions;
using FwksLabs.Libs.AspNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using FwksLabs.Libs.Core.Configuration;
using FwksLabs.Libs.AspNetCore.HealthChecks;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class HealthChecksConfiguration
{
    public static IServiceCollection AddDefaultHealthChecks(this IServiceCollection services)
    {
        services
            .AddHealthChecks();

        return services;
    }

    public static IHealthChecksBuilder AddInternalServiceHealthCheck(this IHealthChecksBuilder builder, string name, string serviceUrl, bool critical) =>
        builder
            .AddCustomHealthCheck(name, sp => new InternalServiceHealthCheck(sp.GetLogger<InternalServiceHealthCheck>(), sp.GetHttpClientFactory(), serviceUrl), critical);

    // TODO: BREAK THE IMPLEMENTATION INTO SEPARATE CLASSES
    public static WebApplication MapHealthCheckEndpoints(this WebApplication builder)
    {
        builder
            .MapHealthChecks("/health/liveness", new()
            {
                Predicate = static _ => false,
                ResultStatusCodes = HealthStatusCodes(),
                ResponseWriter = static (context, report) =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    return context.Response.WriteAsync("Up and running.");
                }
            });

        builder
            .MapHealthChecks("/health/readiness", new()
            {
                ResultStatusCodes = HealthStatusCodes(),
                ResponseWriter = static (context, report) =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    return context.Response.WriteAsync(HealthCheckDependencyReport.From(report));
                }
            });

        return builder;

        static Dictionary<HealthStatus, int> HealthStatusCodes() => new()
        {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status503ServiceUnavailable,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
        };
    }
}
