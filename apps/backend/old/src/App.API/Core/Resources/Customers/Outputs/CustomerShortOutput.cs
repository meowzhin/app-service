using FwksLabs.AppService.Core.Resources.Common.Outputs;

namespace FwksLabs.AppService.Core.Resources.Customers.Outputs;

public sealed record CustomerShortOutput
{
    required public string Id { get; set; }
    required public NameOutput Name { get; set; }
}
