using System.Text.Json.Serialization;
using FwksLabs.Libs.Core.Constants;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FwksLabs.Libs.AspNetCore.Models;

public sealed record HealthCheckDependencyReport
{
    required public string Status { get; set; }
    public IReadOnlyCollection<DependencyStatus> Dependencies { get; set; } = [];

    public static string From(HealthReport report)
    {
        var response = new HealthCheckDependencyReport
        {
            Status = report.Status.ToString(),
            Dependencies = report.Entries.Select(Entry).ToList()
        };

        return response.Serialize();

        static DependencyStatus Entry(KeyValuePair<string, HealthReportEntry> report) =>
            new(report.Key,
                report.Value.Status.ToString(),
                report.Value.Tags.Contains(HealthCheckConstants.Critical));
    }
}

