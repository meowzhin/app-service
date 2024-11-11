using FwksLabs.AppService.App.Api.Services.Common;
using FwksLabs.AppService.Core.Abstractions.Services.Common;

namespace FwksLabs.AppService.App.Api.Services;

public static class ServiceModule
{
    public static IServiceCollection AddServiceModule(this IServiceCollection services) =>
        services
            .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<IValidatorService, ValidatorService>();
}
