using System.Net.Mime;
using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using FwksLabs.Libs.AspNetCore.Models;
using FwksLabs.Libs.Core.Constants;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.AspNetCore.Middlewares;

public sealed class UnexpectedExceptionMiddleware(
    ILogger<UnexpectedExceptionMiddleware> logger,
    IRequestContext requestContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error has occurred.");

            context.Response.ContentType = MediaTypeNames.Application.ProblemJson;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            _ = context.Response.Headers.TryAdd(AppHeaders.CorrelationId, requestContext.CorrelationId);

            await context.Response.WriteAsync(AppProblem.InternalServerError(ex).Serialize());
        }
    }
}
