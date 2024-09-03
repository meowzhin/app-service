using Microsoft.Extensions.DependencyInjection;
using FwksLab.Libs.AspNetCore.Abstractions.Contexts;
using FwksLab.Libs.AspNetCore.Contexts;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class RequestContextConfiguration
{
    public static IServiceCollection AddRequestContext(this IServiceCollection services)
    {
        return services
            .AddScoped<IRequestContext, RequestContext>();
    }
}

