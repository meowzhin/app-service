using FwksLabs.Libs.AspNetCore.Models;

namespace FwksLabs.Libs.AspNetCore.Abstractions.Contexts;

public interface IRequestContext
{
    string CorrelationId { get; }
    public AppProblem? Problem { get; }

    IRequestContext AddCorrelationId(string correlationId);
    IRequestContext AddProblem(AppProblem problem);
    IRequestContext AddProblem(int statusCode, string title, string detail, params KeyValuePair<string, object?>[] extensions);
    IRequestContext AddExtensionProperty(string key, object? value);
}
