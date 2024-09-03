using Microsoft.Extensions.DependencyInjection;

namespace FwksLab.AppService.Infra.Clients;

public static class ClientsModule
{
    public static IServiceCollection AddClientsModule(this IServiceCollection services)
    {
        return services;
    }
}