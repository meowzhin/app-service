using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FwksLabs.Libs.Core.Extensions;

public static class ServiceCollectionExtensions
{
    [Obsolete("NOT QUITE THERE YET. AVOID USING")]
    public static IServiceCollection RegisterFromAssemblyFor<TAssembly, TInterface>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var interfaceType = typeof(TInterface);

        var types = typeof(TAssembly).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t)).ToList();

        foreach (var implementation in types)
        {
            var @interface = implementation.GetInterfaces().SingleOrDefault(x => x != interfaceType && interfaceType.IsAssignableFrom(x));

            if (@interface == null)
                continue;

            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.TryAddSingleton(@interface, implementation);
                    break;
                case ServiceLifetime.Scoped:
                    services.TryAddScoped(@interface, implementation);
                    break;
                case ServiceLifetime.Transient:
                    services.TryAddTransient(@interface, implementation);
                    break;
                default:
                    services.TryAddScoped(@interface, implementation);
                    break;
            }
        }

        return services;
    }
}