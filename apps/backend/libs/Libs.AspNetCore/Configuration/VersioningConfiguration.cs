using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class VersioningConfiguration
{
    public static IServiceCollection OverrideVersioningOptions(this IServiceCollection services) =>
        services
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, CustomApiVersioningOptions>()
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, CustomApiExplorerOptions>();

    public static IServiceCollection OverrideVersioningOptions<TVersioning, TExplorer>(this IServiceCollection services)
        where TVersioning : class, IConfigureOptions<ApiVersioningOptions>
        where TExplorer : class, IConfigureOptions<ApiExplorerOptions> =>
            services
                .AddTransient<IConfigureOptions<ApiVersioningOptions>, TVersioning>()
                .AddTransient<IConfigureOptions<ApiExplorerOptions>, TExplorer>();
}
