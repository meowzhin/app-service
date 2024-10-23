using System.Net.Mime;
using Asp.Versioning;
using FluentValidation;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace FwksLabs.ResumeService.App.Api.Endpoints;

public static class ResumeEndpoints
{
    public static IEndpointRouteBuilder MapResumeEndpoints(this IEndpointRouteBuilder builder)
    {
        var versionSet = builder
            .NewApiVersionSet()
            .HasApiVersion(new(1, 0))
            .HasApiVersion(new(2, 0))
            .ReportApiVersions()
            .Build();

        var group = builder
            .MapGroup("v{version:apiVersion}/resume")
            .WithApiVersionSet(versionSet);

        group
            .MapGet("{profileUrl}", static (string profileUrl) => TypedResults.Ok<ResumeOutput>(new(profileUrl, "Murilo Almeida", "connect@muriloalmeida.dev")))
            .MapToApiVersion(1, 0)
            .WithOpenApi(static x => new OpenApiOperation(x)
            {
                Summary = "Retrieves the resume for the profile url.",
                Tags = [
                    new()
                    {
                        Name = "Profiles",
                        Description = "Endpoints related to user profiles.",
                        ExternalDocs = new OpenApiExternalDocs
                        {
                            Description = "Find out more about user profiles.",
                            Url = new("https://yourdocumentationurl.com/profiles")
                        },
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.Tag,
                            Id = "Profiles"
                        }
                    }
                    ],
                OperationId = "GetResumeByProfileUrl",
                Parameters = [
                    new OpenApiParameter
                    {
                        Name = "profileUrl",
                        In = ParameterLocation.Path,
                        Required = true,
                        Description = "The unique URL associated with the user profile.",
                        Schema = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "uri",
                            Example = new OpenApiString("https://example.com/profile/12345") // Example URL
                        }
                    }
                    ]
            })
            .ProducesProblem(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson);

        group
            .MapGet("{profileUrl}/new", static (string profileUrl) => TypedResults.Ok<ResumeOutput>(new(profileUrl, "Murilo Almeida", "connect@muriloalmeida.dev")))
            .MapToApiVersion(2, 0)
            .WithOpenApi(static x => new OpenApiOperation(x)
            {
                Summary = "Retrieves the resume for the profile url.",
                Tags = [
                    new()
                    {
                        Name = "Profiles",
                        Description = "Endpoints related to user profiles.",
                        ExternalDocs = new OpenApiExternalDocs
                        {
                            Description = "Find out more about user profiles.",
                            Url = new("https://yourdocumentationurl.com/profiles")
                        },
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.Tag,
                            Id = "Profiles"
                        }
                    }
                    ],
                OperationId = "GetResumeByProfileUrl",
                Parameters = [
                    new OpenApiParameter
                    {
                        Name = "profileUrl",
                        In = ParameterLocation.Path,
                        Required = true,
                        Description = "The unique URL associated with the user profile.",
                        Schema = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "uri",
                            Example = new OpenApiString("https://example.com/profile/12345") // Example URL
                        }
                    }
                    ]
            })
            .ProducesProblem(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson);

        return builder;
    }
}

public class ValidationFilter<TRequest>(
    IValidator<TRequest> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments.OfType<TRequest>().First();

        var result = await validator.ValidateAsync(request, context.HttpContext.RequestAborted);

        if (!result.IsValid)
            return TypedResults.ValidationProblem(result.ToDictionary());

        return await next(context);
    }
}

public static class ValidationExtensions
{
    public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder) =>
        builder
        .AddEndpointFilter<ValidationFilter<TRequest>>()
        .ProducesValidationProblem();

    //public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder) =>
    //    builder
    //    .AddEndpointFilter<ValidationFilter<TRequest>>()
    //    .ProducesValidationProblem();
}

public record ResumeOutput(string Profile, string Name, string Email);