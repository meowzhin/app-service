using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.Competencies.Endpoints;

public sealed class DeleteCompetencyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapDelete("{id}", Handle);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        ILogger<DeleteCompetencyEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Deleting competency {Id} for {Name}", id, slug);

        return TypedResults.NoContent();
    }
}
