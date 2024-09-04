namespace FwksLabs.Libs.Core.Security.Options;

public record DocumentationOptions
{
    public object Swagger { get; set; } = new();
}