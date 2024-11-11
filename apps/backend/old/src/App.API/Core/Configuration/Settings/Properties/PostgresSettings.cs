using FwksLabs.Libs.Core.Abstractions;

namespace FwksLabs.AppService.Core.Configuration.Settings.Properties;

public record PostgresSettings : IConnectionStringBuilder
{
    public string Host { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public Dictionary<string, object> Parameters { get; set; } = [];

    public string Build()
    {
        // TODO: Fix this
        var parameters = Parameters.Select(x => $"{x.Key}={x.Value}");

        return string.Join(';', [
            $"Host={Host}",
            $"Username={Username}",
            $"Password={Password}",
            $"Database={Database}",
            ]
        );
    }
}
