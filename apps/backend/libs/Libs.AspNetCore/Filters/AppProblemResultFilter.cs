using System.Net.Mime;
using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.AspNetCore.Filters;

public sealed class AppProblemResultFilter(
    ILogger<AppProblemResultFilter> logger,
    IRequestContext requestContext) : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (requestContext.Problem != null)
        {
            logger.LogError("An error occured: {@Problem}", requestContext.Problem);

            context.HttpContext.Response.ContentType = MediaTypeNames.Application.ProblemJson;
            context.HttpContext.Response.StatusCode = requestContext.Problem.Status;

            await context.HttpContext.Response.WriteAsync(requestContext.Problem.Serialize());

            return;
        }

        await next();
    }
}
