using FwksLab.AppService.Core.Abstractions.Repositories;
using FwksLab.AppService.Core.Configuration.Settings;
using FwksLab.AppService.Infra.Data.Context;
using FwksLab.AppService.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLab.AppService.Infra.Data;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, AppSettings appSettings)
    {
        return services
            .AddDbContext<DatabaseContext>(x => x.UseMongoDB(appSettings.Persistence.Mongo.Build(), appSettings.Persistence.Mongo.Database))
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<ICustomerRepository, CustomerRepository>();
    }
}
