using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FwksLabs.Libs.Core.Configuration;

public static class HealthCheckConfiguration
{
    public static IHealthChecksBuilder AddCustomHealthCheck(this IHealthChecksBuilder builder, string name, Func<IServiceProvider, IHealthCheck> healthCheckFactory, bool critical) =>
        builder.Add(new HealthCheckRegistration(name, healthCheckFactory, null, [critical ? "critical" : "non-critical"]));
}