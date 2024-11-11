using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.Competencies.Endpoints;

public sealed class PatchCompetencyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPatch("{id}", Handle);

    internal record Request(string Name, string Description);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        [FromBody] Request request,
        ILogger<PatchCompetencyEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Updating competency {Id} for {Name}", id, slug);

        return TypedResults.Ok(new { Id = id, UpdatedName = request.Name, UpdatedDescription = request.Description });
    }
}
