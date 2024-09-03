namespace FwksLab.Libs.Core.Security.Options;

// TODO add obfuscation interface to be overwritable
public record ObfuscatorOptions
{
    public int MinLength { get; set; } = 5;
    public string Alphabet { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    public IDictionary<string, int> Tokens { get; set; } = new Dictionary<string, int>();
}
