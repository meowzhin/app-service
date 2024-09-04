namespace FwksLabs.AppService.Core.Resources.Common.Models;

public sealed record PhoneNumberModel
{
    required public string CountryCode { get; set; }
    required public string Number { get; set; }
}
