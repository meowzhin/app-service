using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.AppService.App.Api.Controllers.Common;

[ApiController]
[Route("v{v:apiVersion}/[controller]")]
public abstract class V1Controller : ControllerBase
{
    static internal IResult Ok<T>(T data)
    {
        return Results.Ok(data);
    }

    static internal async Task<IResult> Ok(Func<Task> upstream)
    {
        await upstream();

        return Results.Ok();
    }

    static internal async Task<IResult> Created(Func<Task> upstream)
    {
        await upstream();

        return Results.Created();
    }

    static internal IResult Created<T>(T data)
    {
        return Results.Created(string.Empty, data);
    }

    static internal async Task<IResult> NoContent(Func<Task> upstream)
    {
        await upstream();

        return Results.NoContent();
    }
}