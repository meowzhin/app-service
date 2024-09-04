using Asp.Versioning.ApiExplorer;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class CustomApiExplorerOptions(
    ILogger<CustomApiExplorerOptions> logger) : IConfigureOptions<ApiExplorerOptions>
{
    public void Configure(ApiExplorerOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    }
}
