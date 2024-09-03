using FwksLab.Libs.Core.Security.Options;

namespace FwksLab.AppService.Core.Configuration.Settings;

public record AppSettings
{
    public DocumentationOptions Documentation { get; set; } = new();
    public SecuritySettings Security { get; set; } = new();
    public PersistenceSettings Persistence { get; set; } = new();
    public TogglesSettings Toggles { get; set; } = new();
}
