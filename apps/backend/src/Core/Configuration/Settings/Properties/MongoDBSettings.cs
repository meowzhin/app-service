using FwksLab.Libs.Core.Abstractions;

namespace FwksLab.AppService.Core.Configuration.Settings.Properties;

public record MongoDBSettings : IConnectionStringBuilder
{
    public string[] Hosts { get; set; } = [];
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public Dictionary<string, object> Parameters { get; set; } = [];

    public string Build()
    {
        var parameters = Parameters.Select(x => $"{x.Key}={x.Value}");

        return $"mongodb://{Username}:{Password}@{string.Join(',', Hosts)}/{Database}?{string.Join('&', parameters)}";
    }
}
