using FwksLabs.Libs.Core.Configuration;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class CustomJsonOptions(
    ILogger<CustomJsonOptions> logger) : IConfigureOptions<JsonOptions>
{
    public void Configure(JsonOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        JsonSerializerConfiguration.Configure(options.JsonSerializerOptions);
    }
}
