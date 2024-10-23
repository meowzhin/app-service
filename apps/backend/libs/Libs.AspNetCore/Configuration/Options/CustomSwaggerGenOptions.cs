using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.AspNetCore.Filters;
using FwksLabs.Libs.AspNetCore.Extensions;
using FwksLabs.Libs.Core.Security.Options;
using Humanizer;
using Asp.Versioning.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Builder;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public interface ApiVersionOptions
{
    int[] ApiVersions { get; }
}

public sealed class CustomSwaggerUIOptions(
    ILogger<CustomSwaggerGenOptions> logger) : IConfigureOptions<SwaggerUIOptions>
{
    public void Configure(SwaggerUIOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        //foreach (var version in versionProvider.ApiVersionDescriptions)
        //{
        //    options.SwaggerEndpoint($"/swagger/{version.GroupName}/swagger.json", version.GroupName.ToUpperInvariant());
        //}
        
        options.SwaggerEndpoint($"/swagger/v2/swagger.json", "V2");
    }
}
public sealed class CustomSwaggerGenOptions(
ILogger<CustomSwaggerGenOptions> logger,
    IApiVersionDescriptionProvider versionProvider,
    AuthServerOptions authServer) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());


        foreach (var version in versionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(version.GroupName, new()
            {
                //Title = doc?.Title ?? "Swagger API Service",
                //Description = doc?.Description ?? "API Documentation",
                Title = "Swagger API Service",
                Description = "API Documentation",
                Version = version.GroupName,
                //Contact = new()
                //{
                //    Name = doc?.Contact?.Name,
                //    Email = doc?.Contact?.Email,
                //    Url = doc?.Contact?.Url,
                //},
                //License = new()
                //{
                //    Name = doc?.License?.Name,
                //    Url = doc?.License?.Url
                //},
                //TermsOfService = doc?.TermsOfService
            });            
        }

        options.DescribeAllParametersInCamelCase();

        options.OperationFilter<SwaggerParametersOperationFilter>(new List<OpenApiParameter> {
            new()
            {
                Name = "x-correlation-id",
                Description = "Correlation id used to track the lifecycle of the request throughout the applications.",
                In = ParameterLocation.Header,
                Schema = new() { Type = "string", Format = "uuid" },
                Required = true,
                Example = Example(Guid.NewGuid())
            }
        });

        options.AddJwtBearerSecurityConfiguration();

        options.AddOAuth2SecurityConfiguration(o =>
        {
            o.Authority = authServer.Authority;
            o.Audience = authServer.Audience;
            o.RequireHttpsMetadata = authServer.RequireHttpsMetadata;
            o.Scopes = authServer.Scopes;
        });
    }

    static OpenApiString Example(object input) => new(input.ToString());
}