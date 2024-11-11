using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.AcademicRecords.Endpoints;

public sealed class PostAcademicRecordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPost("", Handle);

    internal record Request(string Institution, string Degree);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromBody] Request request,
        ILogger<PostAcademicRecordEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Adding academic record for {Name} at {Institution}", slug, request.Institution);

        return TypedResults.Created(slug);
    }
}
