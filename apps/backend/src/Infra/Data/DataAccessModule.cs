using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Configuration.Settings;
using FwksLabs.ResumeService.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.ResumeService.Infra.Data;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, AppSettings appSettings) =>
        services;
            //.AddEntityFrameworkPostgres<DatabaseContext>(appSettings.Persistence.Postgres.Build())
            //.AddRepositories();

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IOrderRepository, OrderRepository>();
}
