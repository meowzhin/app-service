using FwksLabs.Libs.Core.Security.Options;

namespace FwksLabs.AppService.Core.Configuration.Settings;

public record AppSettings
{
    public SecuritySettings Security { get; set; } = new();
    public PersistenceSettings Persistence { get; set; } = new();
    public static int[] ApiVersions => [1, 2];
}
