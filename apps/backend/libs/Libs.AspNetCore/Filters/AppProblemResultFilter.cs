using FwksLab.Libs.AspNetCore.Abstractions.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FwksLab.Libs.AspNetCore.Filters;

public sealed class AppProblemResultFilter(
    ILogger<AppProblemResultFilter> logger,
    IRequestContext requestContext) : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (requestContext.Problem != null)
        {
            logger.LogError("An error occured: {@Problem}", requestContext.Problem);

            context.HttpContext.Response.StatusCode = requestContext.Problem.Status;

            await context.HttpContext.Response.WriteAsJsonAsync(requestContext.Problem);

            return;
        }

        await next();
    }
}
