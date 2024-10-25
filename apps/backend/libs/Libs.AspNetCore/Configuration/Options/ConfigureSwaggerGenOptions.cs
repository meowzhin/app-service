using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.AspNetCore.Filters;
using FwksLabs.Libs.AspNetCore.Extensions;
using Humanizer;
using Asp.Versioning.ApiExplorer;
using FwksLabs.Libs.Core.Configuration.Settings;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class ConfigureSwaggerGenOptions(
    ILogger<ConfigureSwaggerGenOptions> logger,
    InfoSettings info,
    AuthoritySettings authority,
    IApiVersionDescriptionProvider versionProvider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        foreach (var version in versionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(version.GroupName, new()
            {
                Title = info.Name,
                Description = info.Description,
                Version = version.GroupName,
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
            o.Name = authority.Name;
            o.Description = authority.Description;
            o.Authority = authority.Authority;
            o.Audience = authority.Audience;
            o.RequireHttpsMetadata = authority.RequireHttpsMetadata;
            o.Scopes = authority.Scopes;
        });
    }

    static OpenApiString Example(object input) => new(input.ToString());
}