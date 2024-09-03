namespace FwksLab.Libs.Core.Security.Options;

public record CorsPolicyOptions
{
    public string Name { get; set; } = string.Empty;
    public string[] Origins { get; set; } = [];
    public string[] ExposedHeaders { get; set; } = [];
    public string[] Headers { get; set; } = [];
    public string Methods { get; set; } = string.Empty;
}