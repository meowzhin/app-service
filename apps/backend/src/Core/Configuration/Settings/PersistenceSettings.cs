using FwksLabs.ResumeService.Core.Configuration.Settings.Properties;

namespace FwksLabs.ResumeService.Core.Configuration.Settings;

public record PersistenceSettings
{
    public PostgresSettings Postgres { get; set; } = new();
    public RedisSettings Redis { get; set; } = new();
}
