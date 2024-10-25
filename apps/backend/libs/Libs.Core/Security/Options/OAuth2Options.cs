using FwksLabs.Libs.Core.Configuration.Settings;

namespace FwksLabs.Libs.Core.Security.Options;

public record OAuth2Options
{
    public string Name { get; set; } = "OAuth2";
    public string Description { get; set; } = "OAuth2 Authorization Code Grant";
    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public bool RequireHttpsMetadata { get; set; } = true;
    public IDictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
}
