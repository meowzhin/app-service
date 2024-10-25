using System;
using FwksLabs.Core;
using FwksLabs.Libs.AspNetCore;
using FwksLabs.ResumeService.Core;
using FwksLabs.ResumeService.Web.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

try
{
    Log.Logger = ConfigureSerilog.AppSettings();

    Info("starting up");

    var builder = WebApplication.CreateBuilder(args);

    var appSettings = builder.Configuration.Get<AppSettings>()!;

    builder.Services.AddSingleton(appSettings)

    // Core Configuration
    .AddSerilog()
    .AddResponseCompression()
    .AddProblemDetails()
    .AddHttpClient()
    .AddHttpContextAccessor()
    .AddSwaggerGen()

    // Options Override
    .OverrideResponseCompression()
    .OverrideSwaggerGenOptions()


    // Modules Configuration


    ;
    var app = builder.Build();

    app
        .MapAppEndpoints();

    Info("running");

    await app.RunAsync();
}
catch (Exception e)
{
    Log.Fatal(e, "App terminated unexpectedly.");
}
finally
{
    Info("shutting down");
}

static void Info(string status) => Log.Information($"App is {status}.");