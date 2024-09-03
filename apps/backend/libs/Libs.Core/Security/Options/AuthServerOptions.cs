namespace FwksLab.Libs.Core.Security.Options;

public record AuthServerOptions
{
    public string Authority { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public bool RequireHttpsMetadata { get; set; }
    public IDictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
}
