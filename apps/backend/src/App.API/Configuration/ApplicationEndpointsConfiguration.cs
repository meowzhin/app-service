using FwksLabs.ResumeService.App.Api.Endpoints;

namespace FwksLabs.ResumeService.App.Api.Configuration;

public static class ApplicationEndpointsConfiguration
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this IEndpointRouteBuilder builder)
    {
        return builder
            .MapResumeEndpoints();
    }
}
