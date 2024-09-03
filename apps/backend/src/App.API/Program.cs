using Serilog;
using FwksLab.Libs.AspNetCore.Configuration;
using FwksLab.AppService.Infra.Clients;
using FwksLab.AppService.Infra.Data;
using FwksLab.AppService.App.Api.Services;
using FwksLab.AppService.Core.Configuration.Settings;
using FwksLab.Libs.Core.Logging;

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
        .AddAuthentication()
        .AddBearerToken().Services
        .AddAuthorization()
        .AddApiVersioning()
        .AddApiExplorer().Services
        .AddEndpointsApiExplorer()
        .AddControllers()

        // Options Override
        .Services
        .OverrideSwaggerGenOptions()
        .OverrideVersioningOptions()
        .OverrideCompressionOptions()
        .OverrideCorsOptions(appSettings.Security.Cors)
        .OverrideAuthOptions(appSettings.Security.AuthServer)
        .OverrideMvcOptions()
        .OverrideJsonOptions()

        // Modules
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

    app.MapControllers();

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
