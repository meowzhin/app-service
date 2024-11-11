using FwksLabs.AppService.Core.Configuration.Settings.Properties;

namespace FwksLabs.AppService.Core.Configuration.Settings;

public record PersistenceSettings
{
    public PostgresSettings Postgres { get; set; } = new();
    public RedisSettings Redis { get; set; } = new();
}
