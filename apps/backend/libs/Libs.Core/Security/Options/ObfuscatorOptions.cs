namespace FwksLabs.Libs.Core.Security.Options;

public record ObfuscatorOptions
{
    public int MinLength { get; set; } = 5;
    public string Alphabet { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    public int Seed { get; set; } = 12345;
}
