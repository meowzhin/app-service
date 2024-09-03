using FwksLab.AppService.Core.Configuration.Settings.Properties;

namespace FwksLab.AppService.Core.Configuration.Settings;

public record PersistenceSettings
{
    public MongoDBSettings Mongo { get; set; } = new();
}
