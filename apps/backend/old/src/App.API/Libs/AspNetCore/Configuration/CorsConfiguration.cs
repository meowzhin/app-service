using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FwksLabCorsOptions = FwksLabs.Libs.Core.Security.Options.CorsOptions;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class CorsConfiguration
{
    public static IServiceCollection OverrideCorsOptions(this IServiceCollection services, FwksLabCorsOptions corsOptions) =>
        services
            .AddSingleton(corsOptions)
            .AddTransient<IConfigureOptions<CorsOptions>, CustomCorsOptions>();

    public static IServiceCollection OverrideCorsOptions<TCors>(this IServiceCollection services)
        where TCors : class, IConfigureOptions<CorsOptions> =>
            services
                .AddTransient<IConfigureOptions<CorsOptions>, TCors>();
}