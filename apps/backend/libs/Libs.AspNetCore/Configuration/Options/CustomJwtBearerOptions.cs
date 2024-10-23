using System.Net.Mime;
using FwksLabs.Libs.AspNetCore.Models;
using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Security.Options;
using Humanizer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class CustomJwtBearerOptions(
    ILogger<CustomJwtBearerOptions> logger,
    AuthServerOptions authServer) : IConfigureOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        options.Authority = authServer.Authority;
        options.Audience = authServer.Audience;
        options.RequireHttpsMetadata = authServer.RequireHttpsMetadata;
        options.Events = new()
        {
            OnAuthenticationFailed = (context) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.ProblemJson;
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                
                    return context.Response.WriteAsync(AppProblem.Unauthorized().Serialize());
                });

                return Task.CompletedTask;
            }
        };
    }
}
