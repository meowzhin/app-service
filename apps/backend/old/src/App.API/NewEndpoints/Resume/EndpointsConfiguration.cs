using FwksLabs.ResumeService.Web.Api.Extensions;
using FwksLabs.ResumeService.Web.Api.Resources.Resume.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Resources.Resume;

internal static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder MapResumeEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("resume/{slug}")
            .WithTags("Resume");

        group
            //.MapEndpoint<GetResumeEndpoint>()
            .MapEndpoint<PatchResumePersonalInfoEndpoint>();
            //.MapEndpoint<DeleteResumeEndpoint>();

        return builder;
    }
}