using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.AcademicRecords.Endpoints;

public sealed class DeleteAcademicRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapDelete("{id}", Handle);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        ILogger<DeleteAcademicRecordEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Deleting academic record {Id} for {Name}", id, slug);

        return TypedResults.NoContent();
    }
}
