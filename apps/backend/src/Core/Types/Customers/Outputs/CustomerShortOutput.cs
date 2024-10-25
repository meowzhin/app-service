using FwksLabs.ResumeService.Core.Resources.Common.Outputs;

namespace FwksLabs.ResumeService.Core.Resources.Customers.Outputs;

public sealed record CustomerShortOutput
{
    required public string Id { get; set; }
    required public NameOutput Name { get; set; }
}
