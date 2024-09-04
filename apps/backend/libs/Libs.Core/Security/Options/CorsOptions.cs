namespace FwksLabs.Libs.Core.Security.Options;

public record CorsOptions
{
    public string Default { get; set; } = "__DEFAULT_CORS_POLICY__";
    public IReadOnlyCollection<CorsPolicyOptions> Policies { get; set; } = [];
}
