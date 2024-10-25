#pragma warning disable IDE0130

using System;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Humanizer;
using System.Linq;
using FwksLabs.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Net.Mime;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.OpenApi.Any;

// LIBS

namespace FwksLabs.Libs.AspNetCore
{
    // Logging
    public static class ConfigureCompression
    {
        public static IServiceCollection OverrideResponseCompression(this IServiceCollection services)
        {
            return services
                .AddTransient<IConfigureOptions<GzipCompressionProviderOptions>, ConfigureGzipCompressionProviderOptions>()
                .AddTransient<IConfigureOptions<BrotliCompressionProviderOptions>, ConfigureBrotliCompressionProviderOptions>()
                .AddTransient<IConfigureOptions<ResponseCompressionOptions>, ConfigureResponseCompressionOptions>();
        }
    }
    public class ConfigureGzipCompressionProviderOptions(
        ILogger<ConfigureGzipCompressionProviderOptions> logger)
        : IConfigureOptions<GzipCompressionProviderOptions>
    {
        public virtual void Configure(GzipCompressionProviderOptions options)
        {
            logger.LogConfiguration();

            options.Level = CompressionLevel.Optimal;
        }
    }
    public class ConfigureBrotliCompressionProviderOptions(
        ILogger<ConfigureBrotliCompressionProviderOptions> logger)
        : IConfigureOptions<BrotliCompressionProviderOptions>
    {
        public virtual void Configure(BrotliCompressionProviderOptions options)
        {
            logger.LogConfiguration();

            options.Level = CompressionLevel.Optimal;
        }
    }
    public class ConfigureResponseCompressionOptions(
        ILogger<ConfigureResponseCompressionOptions> logger)
        : IConfigureOptions<ResponseCompressionOptions>
    {
        public virtual void Configure(ResponseCompressionOptions options)
        {
            logger.LogConfiguration();

            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
            options.Providers.Add<BrotliCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/json", "application/problem+json"]);
        }
    }

    // Swagger
    public static class ConfigureSwagger
    {
        public static IServiceCollection OverrideSwaggerGenOptions(this IServiceCollection services) =>
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

        public static IServiceCollection OverrideSwaggerGenOptions<TConfiguration>(this IServiceCollection services)
            where TConfiguration : class, IConfigureOptions<SwaggerGenOptions> =>
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, TConfiguration>();

        /// <remarks>
        /// This configuration needs to be added as delegate due a limitation in minimal apis where order can impact how IApiVersionDescriptionProvider is resolved.
        /// <href="https://github.com/dotnet/aspnetcore/issues/45972">
        /// </remarks>
        public static IApplicationBuilder UseSwaggerUIEndpoints(this IApplicationBuilder app, IEndpointRouteBuilder endpoints) =>
            app.UseSwaggerUI(options =>
            {
                foreach (var version in endpoints.DescribeApiVersions())
                {
                    var swaggerEndpoint = $"/swagger/{version.GroupName}/swagger.json";
                    //var displayName = $"{apiInfo.Name} {version.GroupName.ToUpperInvariant()}";
                    var displayName = version.GroupName.ToUpperInvariant();

                    options.SwaggerEndpoint(swaggerEndpoint, displayName);
                }

                //options.DocumentTitle = $"{apiInfo.Name} API";
            });
    }
    public class ConfigureSwaggerGenOptions(
        ILogger<ConfigureSwaggerGenOptions> logger) : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            logger.LogConfiguration();

            options.DescribeAllParametersInCamelCase();


            
            options.OperationFilter<SwaggerparametersOperationFilter>(CorrelationId());
        }

        private static OpenApiParameter CorrelationId() => new()
        {
            Name = "x-correlation-id",
            Description = "Correlation id used to track the lifecycle of the request throughout the applications.",
            In = ParameterLocation.Header,
            Schema = SchemaString("uuid"),
            Required = true,
            Example = Example(Guid.NewGuid())
        };
        private static OpenApiString Example(object input) => new(input.ToString());
        private static OpenApiSchema SchemaString(string format) => new() { Type = "string", Format = format };
        public static void AddJwtBearerSecurityConfiguration(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new()
            {
                Name = "Authorization",
                Description = "JWT Bearer Token Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                },
            });
        }
    }
    public sealed class SwaggerparametersOperationFilter(IReadOnlyCollection<OpenApiParameter> parameters) : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];

            foreach (var parameter in parameters)
            {
                if (operation.Parameters.Any(p => p.Name == parameter.Name))
                    continue;

                operation.Parameters.Add(parameter);
            }
        }
    }
}

namespace FwksLabs.Core
{
    public static class ConfigureSerilog
    {
        public static Serilog.ILogger AppSettings()
        {
            var configuration = new LoggerConfiguration();

            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            configuration.ReadFrom.Configuration(appSettings);

            return configuration.CreateLogger();
        }
    }

    public static class LoggerExtensions
    {
        public static void LogConfiguration<TConfiguration>(this ILogger<TConfiguration> logger, LogLevel logLevel = LogLevel.Information) =>
            logger.Log(logLevel, "Configuring '{OptionsType}'", typeof(TConfiguration).Name.Humanize());
    }
}

namespace FwksLabs.Libs.EntityFramework
{

}

namespace FwksLabs.Libs.Mongo
{

}

namespace FwksLabs.Libs.Postgres
{

}

namespace FwksLabs.Libs.Redis
{

}

// APP

namespace FwksLabs.ResumeService.Web.Api
{
    public static class AppEndpointsConfiguration
    {
        public static IEndpointRouteBuilder MapAppEndpoints(this IEndpointRouteBuilder builder)
        {
            return builder
                .MapResumeEndpoints();
        }
    }
    public static class ResumeEndpointsConfiguration
    {
        public static IEndpointRouteBuilder MapResumeEndpoints(this IEndpointRouteBuilder builder)
        {
            var v1 = new ApiVersion(1, 0);
            var v2 = new ApiVersion(2, 0);

            var versionSet = builder
                .NewApiVersionSet()
                .HasApiVersion(v1)
                .HasApiVersion(v2)
                .ReportApiVersions()
                .Build();

            var group = builder.MapGroup("v{version:apiVersion}/resume").WithApiVersionSet(versionSet);

            group
                .MapGet("{profileUrl}", static (string profileUrl) => TypedResults.Ok(profileUrl))
                .MapToApiVersion(v1)
                .WithOpenApi(options => new OpenApiOperation(options))
                .ProducesProblem(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.ProblemJson)
                .ProducesProblem(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson)
                .ProducesProblem(StatusCodes.Status404NotFound, MediaTypeNames.Application.ProblemJson);

            group
                .MapGet("{profileUrl}/newendpoint", static (string profileUrl) => TypedResults.Ok(profileUrl))
                .MapToApiVersion(v2)
                .WithOpenApi(options => new OpenApiOperation(options))
                .ProducesProblem(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.ProblemJson)
                .ProducesProblem(StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson)
                .ProducesProblem(StatusCodes.Status404NotFound, MediaTypeNames.Application.ProblemJson);

            return builder;
        }
    }
}

namespace FwksLabs.ResumeService.Core
{
    public record AppSettings();

    public static class StringExtensions
    {
        public static string Humanize<T>(this Type type) => type.Name.Humanize();
    }
}

namespace FwksLabs.ResumeService.Infra
{

}