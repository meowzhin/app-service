using FwksLab.AppService.Core.Configuration.Settings.Properties;
using FwksLab.Libs.Core.Security.Options;

namespace FwksLab.AppService.Core.Configuration.Settings;

public record SecuritySettings
{
    public CorsOptions Cors { get; set; } = new();
    public ObfuscationSettings Obfuscation { get; set; } = new();
    public AuthServerSettings AuthServer { get; set; } = new();
}
