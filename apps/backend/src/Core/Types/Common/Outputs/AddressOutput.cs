namespace FwksLabs.ResumeService.Core.Resources.Common.Outputs;

public sealed record AddressOutput
{
    required public string Street { get; set; }
    required public string Details { get; set; }
    required public string City { get; set; }
    required public string StateProvince { get; set; }
    required public string Country { get; set; }
    required public string ZipCode { get; set; }
}
