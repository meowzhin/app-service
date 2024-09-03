using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomAuthenticationOptions(
    ILogger<CustomAuthenticationOptions> logger) : IConfigureOptions<AuthenticationOptions>
{
    public void Configure(AuthenticationOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
}
