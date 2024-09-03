using FwksLab.Libs.AspNetCore.Abstractions.Contexts;

namespace FwksLab.AppService.App.Api.Extensions;

public static class RequestContextExtensions
{
    public static IRequestContext AddBadRequest(this IRequestContext requestContext, params KeyValuePair<string, object?>[] extensions) =>
        requestContext.AddProblem(StatusCodes.Status400BadRequest, "Invalid Request", "One or more properties are not valid.", extensions);

    public static IRequestContext AddBadRequest(this IRequestContext requestContext, string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        requestContext.AddProblem(StatusCodes.Status400BadRequest, title, detail, extensions);

    public static IRequestContext AddNotFound(this IRequestContext requestContext, string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        requestContext.AddProblem(StatusCodes.Status404NotFound, title, detail, extensions);

    public static IRequestContext AddValidationErrors(this IRequestContext requestContext, params string[] errors) =>
        requestContext.AddExtensionProperty("validationErrors", errors);
}