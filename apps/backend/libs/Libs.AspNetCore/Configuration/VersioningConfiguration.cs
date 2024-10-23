using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class VersioningConfiguration
{
    public static IServiceCollection OverrideVersioningOptions(this IServiceCollection services, IEnumerable<ApiVersion>? apiVersions = default) =>
        services
            .AddVersionConfiguration(apiVersions)
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, CustomApiVersioningOptions>()
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, CustomApiExplorerOptions>();

    public static IServiceCollection OverrideVersioningOptions<TVersioning, TExplorer>(this IServiceCollection services, IEnumerable<ApiVersion>? apiVersions = default)
        where TVersioning : class, IConfigureOptions<ApiVersioningOptions>
        where TExplorer : class, IConfigureOptions<ApiExplorerOptions> =>
            services
                .AddVersionConfiguration(apiVersions)
                .AddTransient<IConfigureOptions<ApiVersioningOptions>, TVersioning>()
                .AddTransient<IConfigureOptions<ApiExplorerOptions>, TExplorer>();

    private static IServiceCollection AddVersionConfiguration(this IServiceCollection services, IEnumerable<ApiVersion>? apiVersions)
    {
        apiVersions ??= [new(1, 0)];

        return services;
    }
}

public class ApiVersionConfiguration
{
    public IEnumerable<ApiVersion>? Versions { get; }
}