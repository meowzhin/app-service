using FwksLab.Libs.AspNetCore.Abstractions.Contexts;
using FwksLab.Libs.AspNetCore.Models;
using FwksLab.Libs.Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FwksLab.Libs.AspNetCore.Middlewares;

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

            var problem = AppProblem.InternalServerError(ex);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (!context.Response.Headers.TryAdd(AppHeaders.CorrelationId, requestContext.CorrelationId))
                problem.AddExtensionProperty(nameof(AppHeaders.CorrelationId), requestContext.CorrelationId);

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
