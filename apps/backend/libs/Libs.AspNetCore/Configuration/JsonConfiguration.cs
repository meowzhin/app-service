using FwksLab.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class JsonConfiguration
{
    public static IServiceCollection OverrideJsonOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<MvcOptions>, CustomMvcOptions>()
            .AddTransient<IConfigureOptions<JsonOptions>, CustomJsonOptions>();
    }

    public static IServiceCollection OverrideJsonOptions<TMvc, TJson>(this IServiceCollection services)
        where TMvc : class, IConfigureOptions<MvcOptions>
        where TJson : class, IConfigureOptions<JsonOptions>
    {
        return services
            .AddTransient<IConfigureOptions<MvcOptions>, TMvc>()
            .AddTransient<IConfigureOptions<JsonOptions>, TJson>();
    }
}
