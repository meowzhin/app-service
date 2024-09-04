using FwksLabs.Libs.Core.Configuration;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class CustomJsonOptions(
    ILogger<CustomJsonOptions> logger) : IConfigureOptions<JsonOptions>
{
    public void Configure(JsonOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        JsonSerializerConfiguration.Configure(options.JsonSerializerOptions);
    }
}
