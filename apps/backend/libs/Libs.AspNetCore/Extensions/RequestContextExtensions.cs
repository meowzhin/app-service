using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using Microsoft.AspNetCore.Http;

namespace FwksLabs.Libs.AspNetCore.Extensions;

public static class RequestContextExtensions
{
    public static IRequestContext AddBadRequest(this IRequestContext context, params KeyValuePair<string, object?>[] extensions) =>
        context
            .AddProblem(StatusCodes.Status400BadRequest, "Dados Inválidos", "Uma ou mais propriedades não são válidas.", extensions);

    public static IRequestContext AddBadRequest(this IRequestContext context, string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        context
            .AddProblem(StatusCodes.Status400BadRequest, title, detail, extensions);

    public static IRequestContext AddNotFound(this IRequestContext context, string detail, params KeyValuePair<string, object?>[] extensions) =>
        context
            .AddProblem(StatusCodes.Status404NotFound, "Dados não encontrados.", detail, extensions);

    public static IRequestContext AddNotFound(this IRequestContext context, string title, string detail, params KeyValuePair<string, object?>[] extensions) =>
        context
            .AddProblem(StatusCodes.Status404NotFound, title, detail, extensions);

    public static IRequestContext AddValidationErrors(this IRequestContext context, IEnumerable<string> errors) =>
        context
            .AddExtensionProperty("errosValidacao", errors);

    public static IRequestContext AddValidationErrors(this IRequestContext context, params string[] errors) =>
        context
            .AddExtensionProperty("errosValidacao", errors);
}
