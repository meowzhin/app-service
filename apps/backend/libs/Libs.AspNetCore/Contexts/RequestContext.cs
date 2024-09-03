using FwksLab.Libs.AspNetCore.Abstractions.Contexts;
using FwksLab.Libs.AspNetCore.Models;

namespace FwksLab.Libs.AspNetCore.Contexts;

public sealed class RequestContext : IRequestContext
{
    private string _correlationId = string.Empty;

    public AppProblem? Problem { get; set; }
    public string CorrelationId => _correlationId;

    public IRequestContext AddExtensionProperty(string key, object? value)
    {
        _ = Problem?.AddExtensionProperty(key, value);

        return this;
    }

    public IRequestContext AddCorrelationId(string correlationId)
    {
        if (!string.IsNullOrWhiteSpace(_correlationId))
            return this;

        if (!Guid.TryParse(correlationId, out _))
            throw new ArgumentException("Correlation Id is not a valid guid.", nameof(correlationId));

        _correlationId = correlationId;

        return this;
    }

    public IRequestContext AddProblem(AppProblem problem)
    {
        Problem = problem;

        return this;
    }

    public IRequestContext AddProblem(int statusCode, string title, string detail, params KeyValuePair<string, object?>[] extensions)
    {
        Problem = AppProblem.Create(statusCode, title, detail, extensions);

        return this;
    }
}