using FwksLabs.ResumeService.Web.Api.Extensions;
using FwksLabs.ResumeService.Web.Api.Resources.Competencies.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Resources.Competencies;

internal static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder MapCompetenciesEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("cv/{slug}/competencies")
            .WithTags("Competencies");

        group
            .MapEndpoint<PostCompetencyEndpoint>()
            .MapEndpoint<PatchCompetencyEndpoint>()
            .MapEndpoint<DeleteCompetencyEndpoint>();

        return builder;
    }
}
