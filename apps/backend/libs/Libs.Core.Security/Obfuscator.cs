using FwksLab.Libs.Core.Security.Options;
using Sqids;

namespace FwksLab.Libs.Core.Security;

public static class Obfuscator
{
    private readonly static ObfuscatorOptions _options = new();
    private static SqidsEncoder<int>? _instance;

    private static SqidsEncoder<int> Instance
    {
        get
        {
            _instance ??= new(new() { MinLength = 5 });

            return _instance;
        }
    }

    public static void Configure(Action<ObfuscatorOptions>? optionsBuilder = null)
    {
        optionsBuilder?.Invoke(_options);

        _instance = new SqidsEncoder<int>(new()
        {
            MinLength = _options.MinLength,
            Alphabet = _options.Alphabet
        });
    }

    public static string Encode(int value) => Instance.Encode(value);

    public static string Encode(int value, string token)
    {
        if (_options.Tokens.Count == 0)
            return Encode(value);

        return Instance.Encode(value, _options.Tokens[token]);
    }

    public static int Decode(string hash)
    {
        try
        {
            return Instance.Decode(hash)[0];
        }
        catch
        {
            return -1;
        }
    }
}
