using FwksLabs.Libs.Core.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.AspNetCore.HealthChecks;

public sealed class InternalServiceHealthCheck(
    ILogger<InternalServiceHealthCheck> logger,
    IHttpClientFactory httpClientFactory,
    string serviceUrl) 
        : BaseHealthCheck<InternalServiceHealthCheck>(logger), IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            SetContext(context);

            var client = httpClientFactory.CreateClient();

            if (await CheckReadiness(client, serviceUrl, cancellationToken) is false)
                return HealthResult();

            return Healthy();
        }
        catch (Exception ex)
        {
            LogError(ex);

            return Unhealthy();
        }
    }
}
