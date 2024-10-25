using FwksLabs.Libs.Core.Abstractions;

namespace FwksLabs.ResumeService.Core.Configuration.Settings.Properties;

public record RedisSettings : IConnectionStringBuilder
{
    public string Host { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Database { get; set; } = 0;

    public string Build()
    {
        return string.Join(',', [
            $"{Host}",
            $"password={Password}",
            $"defaultDatabase={Database}",
            ]
        );
    }
}