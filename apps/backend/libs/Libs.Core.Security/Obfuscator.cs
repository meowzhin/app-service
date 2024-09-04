using System.Reflection;
using FwksLabs.Libs.Core.Security.Attributes;
using FwksLabs.Libs.Core.Security.Exceptions;
using FwksLabs.Libs.Core.Security.Options;
using Microsoft.Extensions.DependencyInjection;
using Sqids;

namespace FwksLabs.Libs.Core.Security;

public static class Obfuscator
{
    private static SqidsEncoder<int>? _instance;
    private readonly static Dictionary<string, int> _tokens = [];

    public static string Encode(int value)
    {
        if (_instance == null)
            throw new ConfigurationNotFoundException();

        return _instance.Encode(value);
    }

    public static string Encode<TType>(int value) where TType : class
    {
        if (_instance == null)
            throw new ConfigurationNotFoundException();

        if (!_tokens.TryGetValue(typeof(TType).Name, out var token))
            throw new TokenNotFoundException(value);

        return _instance.Encode(value, token);
    }

    public static int Decode(string hash)
    {
        if (_instance == null)
            throw new ConfigurationNotFoundException();

        try
        {
            return _instance.Decode(hash)[0];
        }
        catch
        {
            return -1;
        }
    }

    public static IServiceCollection AddObfuscatorTokensFromAssembly<TAssembly>(this IServiceCollection services, Action<ObfuscatorOptions>? optionsAction = null)
        where TAssembly : class
    {
        var options = new ObfuscatorOptions();

        optionsAction?.Invoke(options);

        SetTokens();

        _instance = new SqidsEncoder<int>(new()
        {
            MinLength = options.MinLength,
            Alphabet = options.Alphabet,
        });

        void SetTokens()
        {
            var types = Assembly.Load(typeof(TAssembly).Assembly.GetName()).GetTypes()
                .Where(x => x.IsClass && x.GetCustomAttribute<ObfuscateResourceAttribute>() is not null)
                .ToList();

            for (var i = 0; i < types.Count; i++)
            {
                var type = types[i];

                if (!_tokens.TryAdd(type.Name, options.Seed + i))
                    throw new DuplicatedTokenException(type.Name);
            }
        }

        return services;
    }
}
