using FwksLab.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FwksLabCorsOptions = FwksLab.Libs.Core.Security.Options.CorsOptions;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class CorsConfiguration
{
    public static IServiceCollection OverrideCorsOptions(this IServiceCollection services, FwksLabCorsOptions corsOptions)
    {
        return services
            .AddSingleton(corsOptions)
            .AddTransient<IConfigureOptions<CorsOptions>, CustomCorsOptions>();
    }

    public static IServiceCollection OverrideCorsOptions<TCors>(this IServiceCollection services)
        where TCors : class, IConfigureOptions<CorsOptions>
    {
        return services
            .AddTransient<IConfigureOptions<CorsOptions>, TCors>();
    }
}