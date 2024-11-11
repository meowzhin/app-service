using FwksLabs.AppService.Core.Resources.Common.Outputs;

namespace FwksLabs.AppService.Core.Resources.Customers.Outputs;

public sealed record CustomerOutput
{
    required public string Id { get; set; }
    required public NameOutput Name { get; set; }
    required public string Email { get; set; }
    required public PhoneNumberOutput Phone { get; set; }
    required public AddressOutput Address { get; set; }
}
