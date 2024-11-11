using FwksLabs.ResumeService.Web.Api.Extensions;
using FwksLabs.ResumeService.Web.Api.Resources.EmploymentHistory.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Resources.EmploymentHistory;

internal static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder MapEmploymentHistoryEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("cv/{slug}/employment-history")
            .WithTags("EmploymentHistory");

        group
            .MapEndpoint<PostEmploymentHistoryEndpoint>()
            .MapEndpoint<PatchEmploymentHistoryEndpoint>()
            .MapEndpoint<DeleteEmploymentHistoryEndpoint>();

        return builder;
    }
}
