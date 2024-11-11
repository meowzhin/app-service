using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Resources.Resume.Endpoints;

public sealed class GetResumeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapGet("", Handle);

    private static async Task<IResult> Handle(
        string slug, 
        ILogger<GetResumeEndpoint> logger,
        IResumeRepository repository)
    {
        var profile = await repository.SearchOneAsync(x => x.Slug == slug);

        if (profile is null)
        {
            logger.LogWarning("Profile not found for {Slug}", slug);

            return TypedResults.NotFound();
        }

        return TypedResults.Ok(profile);
    }
}
