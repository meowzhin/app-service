using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.Resume.Endpoints;

public sealed class DeleteResumeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapDelete("", Handle);
    internal record Request(string ProfileData);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromBody] Request request,
        ILogger<DeleteResumeEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Deleting CV for {Name}", slug);

        return TypedResults.NoContent();
    }
}
