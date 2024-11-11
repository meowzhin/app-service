using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.Competencies.Endpoints;

public sealed class PostCompetencyEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPost("", Handle);

    internal record Request(string Name, string Description);

    internal record Response(Guid Id, string Name, string Description);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromBody] Request request,
        ILogger<PostCompetencyEndpoint> logger)
    {
        await Task.Yield();

        if (string.IsNullOrWhiteSpace(request.Name))
            return TypedResults.BadRequest();

        logger.LogInformation("Creating competency for {Name}: {Competency}", slug, request.Name);

        return TypedResults.Created(slug);
    }
}
