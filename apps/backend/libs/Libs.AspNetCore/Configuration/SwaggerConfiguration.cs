using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using FwksLab.Libs.AspNetCore.Configuration.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection OverrideSwaggerGenOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, CustomSwaggerGenOptions>();
    }

    public static IServiceCollection OverrideSwaggerGenOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, IConfigureOptions<SwaggerGenOptions>
    {
        return services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, TOptions>();
    }
}
