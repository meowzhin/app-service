using FwksLab.Libs.Core.Extensions;
using FwksLab.Libs.Core.Security.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomJwtBearerOptions(
    ILogger<CustomJwtBearerOptions> logger,
    AuthServerOptions authServer) : IConfigureOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.Authority = authServer.Authority;
        options.Audience = authServer.Audience;
        options.RequireHttpsMetadata = authServer.RequireHttpsMetadata;
        options.Events = new()
        {
            OnAuthenticationFailed = (context) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    return context.Response.WriteAsJsonAsync("Authorization Failed");
                });

                return Task.CompletedTask;
            }
        };
    }
}
