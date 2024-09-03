using FwksLab.AppService.App.Api.Services.Application;
using FwksLab.AppService.Core.Abstractions.Services;

namespace FwksLab.AppService.App.Api.Services;

public static class ServiceModule
{
    public static IServiceCollection AddServiceModule(this IServiceCollection services)
    {
        return services
            .AddScoped<ICustomerService, CustomerService>();
    }
}
