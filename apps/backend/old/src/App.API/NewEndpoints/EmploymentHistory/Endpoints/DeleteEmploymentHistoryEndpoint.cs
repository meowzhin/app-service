using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.EmploymentHistory.Endpoints;

public sealed class DeleteEmploymentHistoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapDelete("{id}", Handle);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromRoute] Guid id,
        ILogger<DeleteEmploymentHistoryEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Deleting employment history {Id} for {Name}", id, slug);

        return TypedResults.NoContent();
    }
}
