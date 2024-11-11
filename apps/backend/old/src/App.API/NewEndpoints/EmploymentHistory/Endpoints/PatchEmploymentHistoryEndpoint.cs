using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.EmploymentHistory.Endpoints;

public sealed class PatchEmploymentHistoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPatch("{id}", Handle);

    internal record Request(string Company, string Position);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        [FromBody] Request request,
        ILogger<PatchEmploymentHistoryEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Updating employment history {Id} for {Name}", id, slug);

        return TypedResults.Ok(new { Id = id, UpdatedCompany = request.Company, UpdatedPosition = request.Position });
    }
}
