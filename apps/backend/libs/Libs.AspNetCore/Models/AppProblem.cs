using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FwksLab.Libs.AspNetCore.Models;

public sealed class AppProblem : ProblemDetails
{
    public new int Status { get; set; }

    public static AppProblem Create(Action<AppProblem> problemAction)
    {
        AppProblem problem = new();

        problemAction.Invoke(problem);

        return problem;
    }

    public static AppProblem Create(int status, string title, string detail, params KeyValuePair<string, object?>[] extensions)
    {
        return new()
        {
            Status = status,
            Title = title,
            Detail = detail,
            Extensions = extensions.ToDictionary(x => x.Key, x => x.Value)
        };
    }

    public static AppProblem BadRequest(string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        Create(StatusCodes.Status400BadRequest, title, detail, extensions);

    public static AppProblem Unauthorized(string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        Create(StatusCodes.Status401Unauthorized, title, detail, extensions);

    public static AppProblem Forbidden(string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        Create(StatusCodes.Status403Forbidden, title, detail, extensions);

    public static AppProblem NotFound(string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        Create(StatusCodes.Status404NotFound, title, detail, extensions);

    public static AppProblem InternalServerError(string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        Create(StatusCodes.Status500InternalServerError, title, detail, extensions);

    public static AppProblem InternalServerError(Exception exception) =>
        Create(
            StatusCodes.Status500InternalServerError,
            "An unexpected error occurred.",
            exception.Message,
            [new("innerMessages", exception.ExtractMessages().Skip(1))]
        );

    public AppProblem WithDocs(string instance, string type)
    {
        Instance = instance;
        Type = type;

        return this;
    }

    public AppProblem AddExtensionProperty(string key, object? value)
    {
        Extensions.Add(key, value);

        return this;
    }
}