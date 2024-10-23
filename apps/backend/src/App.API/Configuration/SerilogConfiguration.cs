using FwksLabs.Libs.AspNetCore.Configuration;

namespace FwksLabs.ResumeService.App.Api.Configuration;

internal sealed class SerilogConfiguration
{
    public static Serilog.ILogger Configure() => SerilogConfigurationBuilder
        .Configure()
        .CreateLogger();
}
