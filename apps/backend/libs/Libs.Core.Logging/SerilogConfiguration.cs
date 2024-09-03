using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Settings.Configuration;

namespace FwksLab.Libs.Core.Logging;

public static class SerilogConfiguration
{
    public static ILogger Configure() => Configure("Serilog");

    public static ILogger Configure(string section)
    {
        var options = new ConfigurationReaderOptions { SectionName = section };

        return new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration(), options)
            .CreateLogger();
    }

    private static IConfigurationRoot Configuration() =>
        new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
}