using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using FwksLabs.Libs.Core.Constants;
using Microsoft.AspNetCore.Http;

namespace FwksLabs.Libs.AspNetCore.Middlewares;

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
