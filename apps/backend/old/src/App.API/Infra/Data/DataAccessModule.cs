using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Configuration.Settings;
using FwksLabs.AppService.Infra.Data.Contexts;
using FwksLabs.AppService.Infra.Data.Repositories;
using FwksLabs.Libs.Infra.Postgres.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.AppService.Infra.Data;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, AppSettings appSettings) =>
        services
            .AddEntityFrameworkPostgres<DatabaseContext>(appSettings.Persistence.Postgres.Build())
            .AddRepositories();

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IOrderRepository, OrderRepository>();
}
