using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.AspNetCore.Configuration.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection OverrideSwaggerGenOptions(this IServiceCollection services) =>
        services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, CustomSwaggerGenOptions>();

    public static IServiceCollection OverrideSwaggerGenOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, IConfigureOptions<SwaggerGenOptions> =>
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, TOptions>();
}
