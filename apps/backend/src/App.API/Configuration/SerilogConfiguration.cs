using FwksLabs.Libs.Core.Logging;

namespace FwksLabs.AppService.App.Api.Configuration;

internal sealed class SerilogConfiguration
{
    public static Serilog.ILogger Configure() => SerilogConfigurationBuilder
        .Configure()
        .CreateLogger();
}
