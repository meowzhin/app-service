using Serilog;
using FwksLabs.AppService.Core;
using FwksLabs.AppService.Core.Configuration.Settings;
using FwksLabs.AppService.Infra.Data;
using FwksLabs.AppService.Infra.Clients;
using FwksLabs.AppService.App.Api.Services;
using FwksLabs.AppService.App.Api.Configuration;
using FwksLabs.Libs.AspNetCore.Configuration;

try
{
    Log.Logger = SerilogConfiguration.Configure();

    var builder = WebApplication.CreateBuilder(args);

    var appSettings = builder.Configuration.Get<AppSettings>()!;

    builder.Services
        .AddSingleton(appSettings)
        .AddSingleton(appSettings.Documentation)

        // ASP.NET Core Services
        .AddSerilog()
        .AddSwaggerGen()
        .AddRequestContext()
        .AddUnexpectedExceptionMiddleware()
        .AddRequestCorrelationMiddleware()
        .AddResponseCompression()
        .AddCors()
        .AddHealthChecks(appSettings)
        .AddAuthentication()
        .AddBearerToken().Services
        .AddAuthorization()
        .AddApiVersioning()
        .AddApiExplorer().Services
        .AddHttpContextAccessor()
        .AddEndpointsApiExplorer()
        .AddHttpClient()
        .AddControllers()

        // Options Override
        .Services
        .OverrideSwaggerGenOptions()
        .OverrideVersioningOptions()
        .OverrideCompressionOptions()
        .OverrideCorsOptions(appSettings.Security.Cors)
        .OverrideAuthOptions(appSettings.Security.AuthServer)
        .OverrideMvcOptions()

        // Modules
        .AddCoreModule(appSettings)
        .AddServiceModule()
        .AddClientsModule()
        .AddDataAccessModule(appSettings);

    var app = builder.Build();

    if (appSettings.Toggles.Swagger)
        app.UseSwagger().UseSwaggerUI();

    app
        .UseHttpsRedirection()
        .UseSerilogRequestLogging()
        .UseResponseCompression()
        .UseRequestCorrelationMiddleware()
        .UseUnexpectedExceptionMiddleware()
        .UseRouting()
        .UseCors(appSettings.Security.Cors.Default)
        .UseAuthentication()
        .UseAuthorization();

    app
        .MapHealthCheckEndpoints()
        .MapControllers();

    Log.Information("App is starting up");

    await app.RunAsync();

}
catch (Exception e)
{
    Log.Fatal(e, "App terminated unexpectedly");
}
finally
{
    Log.Information("App is shutting down");

    await Log.CloseAndFlushAsync();
}
