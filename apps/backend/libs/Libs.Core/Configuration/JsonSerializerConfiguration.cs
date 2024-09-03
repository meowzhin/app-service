using System.Text.Json.Serialization;
using System.Text.Json;

namespace FwksLab.Libs.Core.Configuration;

public static class JsonSerializerConfiguration
{
    private static JsonSerializerOptions? _default;

    public static JsonSerializerOptions Default
    {
        get
        {
            if (_default != default)
                return _default;

            _default = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

            };

            Configure(_default);

            return _default;
        }
    }

    public static void Configure(JsonSerializerOptions options)
    {
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.Converters.Add(new JsonStringEnumConverter());
    }
}