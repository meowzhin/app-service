using FwksLab.Libs.AspNetCore.Abstractions.Contexts;
using FwksLab.Libs.Core.Constants;
using Microsoft.AspNetCore.Http;

namespace FwksLab.Libs.AspNetCore.Middlewares;

public sealed class RequestCorrelationMiddleware(
    IRequestContext requestContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue(AppHeaders.CorrelationId, out var correlationId))
        {
            correlationId = Guid.NewGuid().ToString();
        }

        _ = requestContext.AddCorrelationId(correlationId!);

        context.Response.Headers.TryAdd(AppHeaders.CorrelationId, correlationId);

        await next(context);
    }
}
