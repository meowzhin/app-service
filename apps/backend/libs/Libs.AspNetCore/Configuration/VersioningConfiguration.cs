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
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, ConfigureApiVersioningOptions>()
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, ConfigureApiExplorerOptions>();

    public static IServiceCollection OverrideVersioningOptions<TVersioning, TExplorer>(this IServiceCollection services)
        where TVersioning : class, IConfigureOptions<ApiVersioningOptions>
        where TExplorer : class, IConfigureOptions<ApiExplorerOptions> =>
            services
                .AddTransient<IConfigureOptions<ApiVersioningOptions>, TVersioning>()
                .AddTransient<IConfigureOptions<ApiExplorerOptions>, TExplorer>();

    public static IServiceCollection AddEndpointsVersioning(this IServiceCollection services) =>
        services
            .AddEndpointsApiExplorer()
            .AddApiVersioning(x =>
            {
                x.ReportApiVersions = true;
            })
            .AddApiExplorer(x =>
            {
                x.GroupNameFormat = "'v'VVV";
                x.SubstituteApiVersionInUrl = true;
            })
            .Services;
}