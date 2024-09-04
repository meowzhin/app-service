namespace FwksLabs.AppService.Core.Resources.Orders.Inputs;

public sealed record OrderInput
{
    public string? Id { get; private set; }
    public string CustomerId { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public OrderInput WithId(string id)
    {
        Id = id;

        return this;
    }

    public OrderEntity ToEntity() => OrderEntity.From(this);
}