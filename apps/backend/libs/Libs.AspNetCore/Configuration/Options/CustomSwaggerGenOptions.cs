using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FwksLab.Libs.AspNetCore.Filters;
using FwksLab.Libs.AspNetCore.Extensions;
using FwksLab.Libs.Core.Security.Options;
using FwksLab.Libs.Core.Extensions;
using Asp.Versioning.ApiExplorer;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomSwaggerGenOptions(
    ILogger<CustomSwaggerGenOptions> logger,
    IApiVersionDescriptionProvider versionProvider,
    DocumentationOptions docOptions,
    AuthServerOptions authServer) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        var doc = docOptions.Swagger as OpenApiInfo;

        var d2 = System.Text.Json.JsonSerializer.Serialize(docOptions);

        foreach (var version in versionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(version.GroupName, new()
            {
                Title = doc?.Title ?? "Swagger API Service",
                Description = doc?.Description ?? "API Documentation",
                Version = version.GroupName,
                Contact = new()
                {
                    Name = doc?.Contact?.Name,
                    Email = doc?.Contact?.Email,
                    Url = doc?.Contact?.Url,
                },
                License = new()
                {
                    Name = doc?.License?.Name,
                    Url = doc?.License?.Url
                },
                TermsOfService = doc?.TermsOfService
            });
        }

        options.DescribeAllParametersInCamelCase();

        options.OperationFilter<SwaggerParametersOperationFilter>(new List<OpenApiParameter> {
            new()
            {
                Name = "x-correlation-id",
                In = ParameterLocation.Header,
                Schema = new() { Type = "string", Format = "uuid" },
                Required = true,
                Example = Example(Guid.NewGuid())
            }
        });

        options.OperationFilter<JsonIgnorePropertyFilter>();

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