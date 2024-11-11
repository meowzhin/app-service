using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwksLabs.Libs.AspNetCore.Extensions;

public static class ServiceProviderExtensions
{
    public static ILogger<TService> GetLogger<TService>(this IServiceProvider provider) where TService : class => provider.GetRequiredService<ILogger<TService>>();
    public static IHttpClientFactory GetHttpClientFactory(this IServiceProvider provider) => provider.GetRequiredService<IHttpClientFactory>();
    public static TService Get<TService>(this IServiceProvider provider) where TService : class => provider.GetRequiredService<TService>();
}