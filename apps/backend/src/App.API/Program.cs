using Serilog;
using FwksLabs.AppService.Core;
using FwksLabs.AppService.Core.Configuration.Settings;
using FwksLabs.Libs.AspNetCore.Configuration;
using FwksLabs.ResumeService.Infra.Clients;
using FwksLabs.ResumeService.Infra.Data;
using FwksLabs.ResumeService.App.Api.Configuration;
using FwksLabs.ResumeService.App.Api.Services;

try
{
    Log.Logger = SerilogConfiguration.Configure();

    var builder = WebApplication.CreateBuilder(args);

    var appSettings = builder.Configuration.Get<AppSettings>()!;

    builder.Services
        .AddOptions<AppSettings>().Services

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

        // Modules
        .AddCoreModule(appSettings)
        .AddServiceModule()
        .AddClientsModule()
        .AddDataAccessModule(appSettings);

    var app = builder.Build();
    
    // if enabled
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
        .MapApplicationEndpoints();

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
