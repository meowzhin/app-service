using System.Globalization;
using FluentValidation;
using FwksLabs.AppService.Core.Abstractions;
using FwksLabs.AppService.Core.Abstractions.Services;
using FwksLabs.AppService.Core.Configuration.Settings;
using FwksLabs.AppService.Core.Configuration.Settings.Properties;
using FwksLabs.AppService.Core.Services;
using FwksLabs.Libs.Core.Security;
using Microsoft.Extensions.DependencyInjection;

namespace FwksLabs.AppService.Core;

public static class CoreModule
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services, AppSettings appSettings) =>
        services
            .AddServices()
            //.AddRedis(appSettings.Persistence.Redis.Build())
            .AddObfuscator(appSettings.Security.Obfuscator)
            .AddFluentValidation();

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<IOrderService, OrderService>();

    private static IServiceCollection AddObfuscator(this IServiceCollection services, ObfuscatorSettings settings) =>
        services
            .AddObfuscatorTokensFromAssembly<ICoreAssembly>(x =>
            {
                x.MinLength = settings.MinLength;
                x.Alphabet = settings.Alphabet;
                x.Seed = settings.Seed;
            });

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

        return services
            .AddValidatorsFromAssemblyContaining<ICoreAssembly>();
    }
}
