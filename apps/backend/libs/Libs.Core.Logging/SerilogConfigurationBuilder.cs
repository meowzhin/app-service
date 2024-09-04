using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Settings.Configuration;

namespace FwksLabs.Libs.Core.Logging;

public static class SerilogConfigurationBuilder
{
    public static LoggerConfiguration Configure()
    {
        var conf = new LoggerConfiguration()
            .ReadFrom.Configuration(ReadAppSettings());

        return conf;
    }

    public static LoggerConfiguration Configure(string section)
    {
        var options = new ConfigurationReaderOptions { SectionName = section };

        var conf = new LoggerConfiguration()
            .ReadFrom.Configuration(ReadAppSettings(), options);

        return conf;
    }

    private static IConfigurationRoot ReadAppSettings() =>
        new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
}