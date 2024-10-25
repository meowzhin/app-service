using FwksLabs.Libs.Core.Security.Options;
using FwksLabs.ResumeService.Core.Configuration.Settings.Properties;

namespace FwksLabs.ResumeService.Core.Configuration.Settings;

public record SecuritySettings
{
    public CorsOptions Cors { get; set; } = new();
    public ObfuscatorSettings Obfuscator { get; set; } = new();
    public AuthServerSettings AuthServer { get; set; } = new();
}
