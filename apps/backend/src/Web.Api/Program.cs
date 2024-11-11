using FwksLabs.Libs.AspNetCore.Configuration;
using FwksLabs.ResumeService.Core.Configuration.Settings;
using FwksLabs.ResumeService.Web.Api.Resources;
using FwksLabs.ResumeService.Infra;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var appSettings = builder.Configuration.Get<AppSettings>()!;

    builder.Services
        .AddSingleton(appSettings)
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()

        // Overrides
        .OverrideSwaggerGenOptions()

        // Modules
        .AddInfraModule(appSettings);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapEndpoints();

    await app.RunAsync();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
