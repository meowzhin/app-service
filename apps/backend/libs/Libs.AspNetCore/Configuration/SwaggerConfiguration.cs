using FwksLabs.Libs.AspNetCore.Overrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection OverrideSwaggerGenOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, OverrideSwaggerGenOptions>();
    }

    public static IServiceCollection OverrideSwaggerGenOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, IConfigureOptions<SwaggerGenOptions>
    {
        return services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, TOptions>();
    }
}
