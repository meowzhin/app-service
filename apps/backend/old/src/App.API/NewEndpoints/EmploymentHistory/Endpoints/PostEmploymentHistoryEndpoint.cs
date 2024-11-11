using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.EmploymentHistory.Endpoints;

public sealed class PostEmploymentHistoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPost("", Handle);

    internal record Request(string Company, string Position);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromBody] Request request,
        ILogger<PostEmploymentHistoryEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Adding employment history for {Name} at {Company}", slug, request.Company);

        return TypedResults.Created(slug);
    }
}
