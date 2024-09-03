using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using FwksLab.Libs.AspNetCore.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class VersioningConfiguration
{
    public static IServiceCollection OverrideVersioningOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, CustomApiVersioningOptions>()
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, CustomApiExplorerOptions>();
    }

    public static IServiceCollection OverrideVersioningOptions<TVersioning, TExplorer>(this IServiceCollection services)
        where TVersioning : class, IConfigureOptions<ApiVersioningOptions>
        where TExplorer : class, IConfigureOptions<ApiExplorerOptions>
    {
        return services
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, TVersioning>()
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, TExplorer>();
    }
}
