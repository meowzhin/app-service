using FwksLabs.ResumeService.Core.Enums;
using FwksLabs.ResumeService.Core.Resources.Customers.Outputs;

namespace FwksLabs.ResumeService.Core.Resources.Orders.Outputs;

public sealed record OrderOutput
{
    required public string Id { get; set; }
    required public CustomerShortOutput Customer { get; set; }
    required public DateTime Date { get; set; }
    required public decimal Amount { get; set; }
    public DateTime? PaymentDate { get; set; }
    required public OrderStatus Status { get; set; }
}