using FwksLabs.Libs.Core.Extensions;
using FwksLabs.Libs.Core.Attributes;
using FwksLabs.ResumeService.Core.Resources.Orders.Outputs;
using FwksLabs.ResumeService.Core.Resources.Orders.Inputs;
using FwksLabs.ResumeService.Core.Resources.Customers;
using FwksLabs.ResumeService.Core.Enums;
using FwksLabs.ResumeService.Core.Extensions;
using FwksLabs.Libs.Core.Types;

namespace FwksLabs.ResumeService.Core.Resources.Orders;

[ObfuscateResource]
public sealed class OrderEntity : Entity<int>
{
    required public int CustomerId { get; set; }
    required public DateTime Date { get; set; }
    required public decimal Amount { get; set; }
    public DateTime? PaymentDate { get; set; }
    required public OrderStatus Status { get; set; }

    public CustomerEntity? Customer { get; set; }

    public static OrderEntity From(OrderInput input) => new()
    {
        CustomerId = input.CustomerId.Decode(),
        Date = DateTime.UtcNow,
        Amount = input.Amount,
        Status = OrderStatus.Pending
    };

    public OrderOutput ToOutput() => new()
    {
        Id = this.EncodeId(),
        Customer = new()
        {
            Id = Customer!.EncodeId(),
            Name = new(Customer!.Name.First, Customer!.Name.Last),
        },
        Date = Date,
        Amount = Amount,
        PaymentDate = PaymentDate,
        Status = Status
    };
}