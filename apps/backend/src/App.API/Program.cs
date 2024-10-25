using Serilog;
using FwksLabs.Libs.AspNetCore.Configuration;
using FwksLabs.ResumeService.Infra.Clients;
using FwksLabs.ResumeService.Infra.Data;
using FwksLabs.ResumeService.App.Api.Configuration;
using FwksLabs.ResumeService.App.Api.Services;
using FwksLabs.ResumeService.Core.Configuration.Settings;
using FwksLabs.ResumeService.Core;

try
{
    Log.Logger = SerilogConfiguration.Configure();

    var builder = WebApplication.CreateBuilder(args);

    var appSettings = builder.Configuration.Get<AppSettings>()!;

    builder.Services
        

        // ASP.NET Core Services
        
        .AddSwaggerGen()
        .AddRequestContext()
        .AddUnexpectedExceptionMiddleware()
        .AddRequestCorrelationMiddleware()
        
        .AddCors()
        .AddHealthChecks(appSettings)
        .AddAuthentication()
        .AddBearerToken().Services
        .AddAuthorization()
        .AddEndpointsVersioning()

        // Options Override
        .OverrideSwaggerGenOptions()
        .OverrideVersioningOptions()
        
        //.OverrideCorsOptions(appSettings.Security.Cors)
        //.OverrideAuthOptions(appSettings.Security.AuthServer)

        // Modules
        .AddCoreModule(appSettings)
        .AddServiceModule()
        .AddClientsModule()
        .AddDataAccessModule(appSettings);

    var app = builder.Build();
  
    app
        .UseHttpsRedirection()
        .UseSerilogRequestLogging()
        .UseResponseCompression()
        .UseRequestCorrelationMiddleware()
        .UseUnexpectedExceptionMiddleware()
        .UseRouting()
        //.UseCors(appSettings.Security.Cors.Default)
        .UseAuthentication()
        .UseAuthorization();

    app
        .MapHealthCheckEndpoints()
        .MapApplicationEndpoints();

    // if enabled
    app
        .UseSwagger()
        .UseSwaggerUIEndpoints(appSettings.Info, app);

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
