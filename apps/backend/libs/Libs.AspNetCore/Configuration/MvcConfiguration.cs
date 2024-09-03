using FwksLab.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class MvcConfiguration
{
    public static IServiceCollection OverrideMvcOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<MvcOptions>, CustomMvcOptions>();
    }

    public static IServiceCollection OverrideMvcOptions<TMvc>(this IServiceCollection services)
        where TMvc : class, IConfigureOptions<MvcOptions>
    {
        return services
            .AddTransient<IConfigureOptions<MvcOptions>, TMvc>();
    }
}