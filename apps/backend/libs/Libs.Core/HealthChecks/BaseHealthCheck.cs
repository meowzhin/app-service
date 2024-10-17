using FwksLabs.Libs.Core.Constants;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.Core.HealthChecks;

public abstract class BaseHealthCheck<THealthCheck>(ILogger<THealthCheck> logger) where THealthCheck : IHealthCheck
{
    protected readonly ILogger<THealthCheck> Logger = logger;

    private HealthCheckContext? _context;
    private bool _isCritical = true;

    protected void SetContext(HealthCheckContext context)
    {
        _context = context;
        _isCritical = context.Registration.Tags.Contains(HealthCheckConstants.Critical);
    }

    protected HealthCheckResult Healthy(string message, IReadOnlyDictionary<string, object>? data = null) =>
        HealthCheckResult.Healthy($"{_context!.Registration.Name} {message}", data);

    protected HealthCheckResult Healthy(IReadOnlyDictionary<string, object>? data = null) => Healthy("is healthy.", data);

    protected HealthCheckResult HealthResult(string message, IReadOnlyDictionary<string, object>? data = null) =>
        _isCritical ? Unhealthy(message, data) : Degraded(message, data);

    protected HealthCheckResult HealthResult(IReadOnlyDictionary<string, object>? data = null) => HealthResult("is not healthy.", data);

    protected HealthCheckResult Degraded(string message, IReadOnlyDictionary<string, object>? data = null) =>
        HealthCheckResult.Degraded($"{_context!.Registration.Name} {message}", data: data);

    protected HealthCheckResult Degraded(IReadOnlyDictionary<string, object>? data = null) => Degraded("is degraded.", data);

    protected HealthCheckResult Unhealthy(string message, IReadOnlyDictionary<string, object>? data = null) =>
        HealthCheckResult.Unhealthy($"{_context!.Registration.Name} {message}", data: data);

    protected HealthCheckResult Unhealthy(IReadOnlyDictionary<string, object>? data = null) => Unhealthy("is unhealthy.", data);

    protected async Task<bool> CheckLiveness(HttpClient client, string serviceUrl, CancellationToken cancellationToken = default) =>
        (await CheckDependencyHealth(client, serviceUrl, "liveness", cancellationToken)).IsSuccessStatusCode;

    protected async Task<bool> CheckReadiness(HttpClient client, string serviceUrl, CancellationToken cancellationToken = default) =>
        (await CheckDependencyHealth(client, serviceUrl, "readiness", cancellationToken)).IsSuccessStatusCode;

    protected void LogError(Exception ex) => Logger.LogError(ex, "Error checking '{name}'\'s health.", _context!.Registration.Name);

    private static Task<HttpResponseMessage> CheckDependencyHealth(HttpClient client, string serviceUrl, string endpoint, CancellationToken cancellationToken = default) =>
        client.GetAsync($"{serviceUrl}/health/{endpoint}", cancellationToken);

    public virtual async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, Func<Task> operation, CancellationToken cancellationToken = default)
    {
        try
        {
            SetContext(context);

            await operation();

            return Healthy();
        }
        catch (Exception ex)
        {
            LogError(ex);

            return HealthResult();
        }
    }
}