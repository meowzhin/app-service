using FwksLabs.ResumeService.App.Api.Services.Common;
using FwksLabs.ResumeService.Core.Abstractions.Services.Common;

namespace FwksLabs.ResumeService.App.Api.Services;

public static class ServiceModule
{
    public static IServiceCollection AddServiceModule(this IServiceCollection services) =>
        services
            .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<IValidatorService, ValidatorService>();
}
