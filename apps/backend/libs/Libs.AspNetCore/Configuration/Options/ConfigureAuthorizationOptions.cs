using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class ConfigureAuthorizationOptions(
    ILogger<ConfigureAuthorizationOptions> logger) : IConfigureOptions<AuthorizationOptions>
{
    public void Configure(AuthorizationOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());
    }
}
