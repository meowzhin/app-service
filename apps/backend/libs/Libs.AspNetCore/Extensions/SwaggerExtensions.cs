using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using FwksLabs.Libs.Core.Security.Options;

namespace FwksLabs.Libs.AspNetCore.Extensions;

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

    public static void AddOAuth2SecurityConfiguration(this SwaggerGenOptions options, Action<OAuth2Options> optionsAction)
    {
        OAuth2Options oauth = new();

        optionsAction?.Invoke(oauth);

        options.AddSecurityDefinition(oauth.Name, new()
        {
            Description = oauth.Description,
            Type = SecuritySchemeType.OAuth2,
            Flows = new()
            {
                AuthorizationCode = new()
                {
                    AuthorizationUrl = new Uri($"{oauth.Authority}/protocol/openid-connect/auth"),
                    TokenUrl = new Uri($"{oauth.Authority}/protocol/openid-connect/token"),
                    Scopes = oauth.Scopes
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
                        Id = oauth.Name
                    }
                },
                oauth.Scopes.Select(static x => x.Key).ToArray()
            },
        });
    }
}
