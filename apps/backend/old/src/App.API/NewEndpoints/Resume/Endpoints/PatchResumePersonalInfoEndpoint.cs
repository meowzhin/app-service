using FwksLabs.ResumeService.Core.OwnedTypes;
using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources.Resume.Endpoints;

public sealed class PatchResumePersonalInfoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPatch("personal-info", Handle);

    internal record Request(string Slug, NameOwnedType Name, string Title, string Summary, LocationOwnedType Location);

    private static async Task<IResult> Handle(
        [FromRoute] string slug,
        [FromBody] Request request,
        ILogger<PatchResumePersonalInfoEndpoint> logger)
    {
        await Task.Yield();

        logger.LogInformation("Updating profile for {Name}", slug);

        return TypedResults.Ok(new { Name = slug, UpdatedProfile = request });
    }
}