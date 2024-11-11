using FwksLabs.ResumeService.Web.Api.Extensions;
using FwksLabs.ResumeService.Web.Api.Resources.AcademicRecords.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Resources.AcademicRecords;

internal static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder MapAcademicRecordsEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("cv/{slug}/academic-records")
            .WithTags("AcademicRecords");

        group
            .MapEndpoint<PostAcademicRecordEndpoint>()
            .MapEndpoint<PatchAcademicRecordEndpoint>()
            .MapEndpoint<DeleteAcademicRecordEndpoint>();

        return builder;
    }
}
