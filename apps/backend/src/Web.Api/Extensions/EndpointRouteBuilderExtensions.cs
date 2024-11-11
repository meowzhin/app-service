using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;

namespace FwksLabs.ResumeService.Web.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder builder) where T : IEndpoint
    {
        T.Map(builder);

        return builder;
    }
}
