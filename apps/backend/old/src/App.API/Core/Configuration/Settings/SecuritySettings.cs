using FwksLabs.AppService.Core.Configuration.Settings.Properties;
using FwksLabs.Libs.Core.Security.Options;

namespace FwksLabs.AppService.Core.Configuration.Settings;

public record SecuritySettings
{
    public CorsOptions Cors { get; set; } = new();
    public ObfuscatorSettings Obfuscator { get; set; } = new();
    public AuthServerSettings AuthServer { get; set; } = new();
}
