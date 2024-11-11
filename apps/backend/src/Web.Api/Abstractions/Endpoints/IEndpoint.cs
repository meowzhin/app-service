namespace FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder builder);
}
