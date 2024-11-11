using FwksLabs.ResumeService.Core.Abstractions.Repositories;
using FwksLabs.ResumeService.Core.Configuration.Settings;
using FwksLabs.ResumeService.Infra.Data;
using FwksLabs.ResumeService.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.ResumeService.Infra;

public static class InfraModule
{
    public static IServiceCollection AddInfraModule(this IServiceCollection services, AppSettings appSettings) =>
        services
            .AddDataModule(appSettings);

    private static IServiceCollection AddDataModule(this IServiceCollection services, AppSettings appSettings) =>
        services
            .AddDbContext<DatabaseContext>(x => x.UseNpgsql(appSettings.Postgres.ConnectionString))
            .AddScoped<IResumeRepository, ResumeRepository>();
}
