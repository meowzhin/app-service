using System.Text.Json;
using FwksLabs.Libs.Core.Configuration;

namespace FwksLabs.Libs.Core.Extensions;

public static class SerializationExtensions
{
    public static string Serialize(this object source, Action<JsonSerializerOptions>? optionsAction = null) =>
        JsonSerializer.Serialize(source, BuildOptions(optionsAction));

    public static T Deserialize<T>(this string source, Action<JsonSerializerOptions>? optionsAction = null) =>
        JsonSerializer.Deserialize<T>(source, BuildOptions(optionsAction))!;

    private static JsonSerializerOptions BuildOptions(Action<JsonSerializerOptions>? optionsAction)
    {
        JsonSerializerOptions options = JsonSerializerConfiguration.Options;

        optionsAction?.Invoke(options);

        return options;
    }
}
