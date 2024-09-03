using System.Text.Json;
using System.Text.Json.Serialization;
using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomJsonOptions(
    ILogger<CustomJsonOptions> logger) : IConfigureOptions<JsonOptions>
{
    public void Configure(JsonOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
}
