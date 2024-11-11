using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.AspNetCore.Abstractions.Contexts;
using FwksLabs.Libs.AspNetCore.Contexts;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class RequestContextConfiguration
{
    public static IServiceCollection AddRequestContext(this IServiceCollection services) =>
        services
            .AddScoped<IRequestContext, RequestContext>();
}

