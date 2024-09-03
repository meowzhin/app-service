using Asp.Versioning;
using FwksLab.Libs.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomApiVersioningOptions(
    ILogger<CustomApiVersioningOptions> logger) : IConfigureOptions<ApiVersioningOptions>
{
    public void Configure(ApiVersioningOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    }
}
