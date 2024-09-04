using FwksLabs.Libs.Core.Security.Options;

namespace FwksLabs.AppService.Core.Configuration.Settings;

public record AppSettings
{
    public DocumentationOptions Documentation { get; set; } = new();
    public SecuritySettings Security { get; set; } = new();
    public PersistenceSettings Persistence { get; set; } = new();
    public TogglesSettings Toggles { get; set; } = new();
}
