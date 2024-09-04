using FwksLabs.Libs.AspNetCore.Configuration.Options;
using FwksLabs.Libs.Core.Security.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class AuthConfiguration
{
    public static IServiceCollection OverrideAuthOptions(this IServiceCollection services, AuthServerOptions authOptions) =>
        services
            .AddSingleton(authOptions)
            .AddTransient<IConfigureOptions<AuthenticationOptions>, CustomAuthenticationOptions>()
            .AddTransient<IConfigureOptions<JwtBearerOptions>, CustomJwtBearerOptions>()
            .AddTransient<IConfigureOptions<AuthorizationOptions>, CustomAuthorizationOptions>();

    public static IServiceCollection OverrideAuthOptions<TAuthentication, TJwtBearer, TAuthorization>(this IServiceCollection services)
        where TAuthentication : class, IConfigureOptions<AuthenticationOptions>
        where TJwtBearer : class, IConfigureOptions<JwtBearerOptions>
        where TAuthorization : class, IConfigureOptions<AuthorizationOptions> =>
            services
                .AddTransient<IConfigureOptions<AuthenticationOptions>, TAuthentication>()
                .AddTransient<IConfigureOptions<JwtBearerOptions>, TJwtBearer>()
                .AddTransient<IConfigureOptions<AuthorizationOptions>, TAuthorization>();
}
