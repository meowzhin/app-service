using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FwksLabs.Libs.AspNetCore.Overrides;

public sealed class OverrideSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public static readonly string[] ValidTypes = ["Request", "Response"];

    public void Configure(SwaggerGenOptions options)
    {
        options.CustomSchemaIds(ConfigureRequestResponseSchemaIds());
    }

    private static Func<Type, string> ConfigureRequestResponseSchemaIds()
    {
        return type =>
        {
            if (ValidTypes.Contains(type.Name))
                return $"{type.DeclaringType?.Name}{type.Name}";

            return type.Name;
        };
    }
}