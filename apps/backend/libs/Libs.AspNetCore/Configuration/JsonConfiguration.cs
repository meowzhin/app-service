using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class JsonConfiguration
{
    public static IServiceCollection OverrideJsonOptions(this IServiceCollection services) =>
        services
            .AddTransient<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>()
            .AddTransient<IConfigureOptions<JsonOptions>, ConfigureJsonOptions>();

    public static IServiceCollection OverrideJsonOptions<TMvc, TJson>(this IServiceCollection services)
        where TMvc : class, IConfigureOptions<MvcOptions>
        where TJson : class, IConfigureOptions<JsonOptions> =>
            services
                .AddTransient<IConfigureOptions<MvcOptions>, TMvc>()
                .AddTransient<IConfigureOptions<JsonOptions>, TJson>();
}
