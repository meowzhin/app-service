using FluentValidation;
using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Entities;
using FwksLabs.ResumeService.Core.OwnedTypes;
using FwksLabs.ResumeService.Web.Api.Abstractions.Endpoints;
using FwksLabs.ResumeService.Web.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.ResumeService.Web.Api.Resources;

internal static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        return builder
            .MapPersonalEndpoints();
        //.MapCompetenciesEndpoints()
        //.MapEmploymentHistoryEndpoints()
        //.MapAcademicRecordsEndpoints();
    }
}

///cv/{slug}
///resumes
///resumes/{id}/personal
///resumes/{id}/social
///resumes/{id}/contact
///resumes/{id}/competencies
///resumes/{id}/competencies/{id}
///resumes/{id}/academic-records
///resumes/{id}/academic-records/{id}
///resumes/{id}/employment-history
///resumes/{id}/employment-history/{id}

internal static class ResumeEndpointsConfiguration
{
    public static IEndpointRouteBuilder WithResumeGroup(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGroup("resumes")
            .WithTags("Resumes");

        return builder;
    }

    public static IEndpointRouteBuilder MapPersonalEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .WithResumeGroup()
            .MapEndpoint<CreateResumeEndpoint>();

        return builder;
    }
}

public sealed class CreateResumeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) =>
        builder.MapPost("", Handler);

    internal record Request(string Slug, NameOwnedType Name, string Title, string Summary);

    private static async Task<IResult> Handler(
        Request request,
        IResumeRepository repository,
        IValidator<Request> validator,
        CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
            return TypedResults.BadRequest(result.Errors);

        var resume = new ResumeEntity
        {
            Slug = "",
            Name = new("", "", null),
            Title = "",
            Summary = ""
        };

        await repository.AddAsync(resume, cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);

        return TypedResults.Ok();
    }

    internal class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator(
            IResumeRepository repository)
        {
            RuleFor(x => x.Slug)
                .MustAsync(async (slug, cancellationToken) => 
                    await repository.ExistsAsync(x => x.Slug == slug, cancellationToken));
        }
    }
}