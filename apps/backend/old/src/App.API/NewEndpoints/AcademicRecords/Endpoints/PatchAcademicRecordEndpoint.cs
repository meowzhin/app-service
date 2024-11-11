using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.AcademicRecords.Endpoints;

public sealed class PatchAcademicRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPatch("{id}", Handle);

    internal record Request2(string Institution, string Degree);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        [FromBody] Request2 request,
        ILogger<PatchAcademicRecordEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Updating academic record {Id} for {Name}", id, slug);

        return TypedResults.Ok(new { Id = id, UpdatedInstitution = request.Institution, UpdatedDegree = request.Degree });
    }
}
