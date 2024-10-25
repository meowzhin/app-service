namespace FwksLabs.Libs.Core.Configuration.Settings;

public record AuthoritySettings(
    string Name,
    string Description,
    string Authority, 
    string Audience, 
    bool RequireHttpsMetadata, 
    IDictionary<string, string> Scopes);