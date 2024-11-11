using System.Text.Json.Serialization;
using System.Text.Json;

namespace FwksLabs.Libs.Core.Configuration;

public static class JsonSerializerConfiguration
{
    private static JsonSerializerOptions? _options;
    private static readonly object _lock = new();

    public static JsonSerializerOptions Options
    {
        get
        {
            if (_options is not null)
                return _options;

            lock (_lock)
            {
                if (_options is not null)
                    return _options;

                _options = new();

                Configure(_options);

                return _options;
            }
        }
    }

    public static void Configure(JsonSerializerOptions options)
    {
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.WriteIndented = false;
        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.Converters.Add(new JsonStringEnumConverter());
    }
}