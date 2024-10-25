namespace FwksLabs.ResumeService.Core.Resources.Common.Inputs;

public sealed record AddressInput
{
    public string Street { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StateProvince { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}
