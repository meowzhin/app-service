using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using FwksLabs.Libs.Core.Configuration.Settings;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection OverrideSwaggerGenOptions(this IServiceCollection services) =>
        services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

    public static IServiceCollection OverrideSwaggerGenOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, IConfigureOptions<SwaggerGenOptions> =>
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, TOptions>();

    /// <remarks>
    /// This configuration needs to be added as delegate due a limitation in minimal apis where order can impact how IApiVersionDescriptionProvider is resolved.
    /// <href="https://github.com/dotnet/aspnetcore/issues/45972">
    /// </remarks>
    public static IApplicationBuilder UseSwaggerUIEndpoints(this IApplicationBuilder app, InfoSettings apiInfo, IEndpointRouteBuilder endpoints)
    {
        return app.UseSwaggerUI(options =>
        {
            foreach (var version in endpoints.DescribeApiVersions())
            {
                var swaggerEndpoint = $"/swagger/{version.GroupName}/swagger.json";
                var displayName = $"{apiInfo.Name} {version.GroupName.ToUpperInvariant()}";

                options.SwaggerEndpoint(swaggerEndpoint, displayName);
            }

            options.DocumentTitle = $"{apiInfo.Name} API";
        });
    }

}
