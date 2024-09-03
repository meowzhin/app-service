namespace FwksLab.AppService.Core.Configuration.Settings.Properties;

public record ObfuscationSettings
{
    public string Alphabet { get; set; } = string.Empty;
    public int MinLength { get; set; } = 5;
}
