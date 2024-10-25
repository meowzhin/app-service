using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class ConfigureAuthenticationOptions(
    ILogger<ConfigureAuthenticationOptions> logger) : IConfigureOptions<AuthenticationOptions>
{
    public void Configure(AuthenticationOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
}
