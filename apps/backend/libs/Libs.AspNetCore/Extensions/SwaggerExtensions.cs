using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using FwksLab.Libs.Core.Security.Options;

namespace FwksLab.Libs.AspNetCore.Extensions;

public static class SwaggerExtensions
{
    public static void AddJwtBearerSecurityConfiguration(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("Bearer", new()
        {
            Name = "Authorization",
            Description = "JWT Bearer Token Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                },
            });
    }

    public static void AddOAuth2SecurityConfiguration(this SwaggerGenOptions options, Action<AuthServerOptions> authServerAction)
    {
        AuthServerOptions authServer = new();

        authServerAction?.Invoke(authServer);

        options.AddSecurityDefinition("OAuth2", new()
        {
            Description = "OAuth2 Authorization Code Grant",
            Type = SecuritySchemeType.OAuth2,
            Flows = new()
            {
                AuthorizationCode = new()
                {
                    AuthorizationUrl = new Uri($"{authServer.Authority}/protocol/openid-connect/auth"),
                    TokenUrl = new Uri($"{authServer.Authority}/protocol/openid-connect/token"),
                    Scopes = authServer.Scopes
                }
            }
        });

        options.AddSecurityRequirement(new()
        {
            {
                new()
                {
                    Reference = new()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "OAuth2"
                    }
                },
                authServer.Scopes.Select(x => x.Key).ToArray()
            },
        });
    }
}
