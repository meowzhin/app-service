namespace FwksLabs.ResumeService.Core.Configuration.Settings.Properties;

public record ObfuscatorSettings
{
    public string Alphabet { get; set; } = string.Empty;
    public int MinLength { get; set; }
    public int Seed { get; set; }
}
