using FwksLabs.AppService.Core.Resources.Common.Inputs;

namespace FwksLabs.AppService.Core.Resources.Customers.Inputs;

public sealed record CustomerInput
{
    public string? Id { get; private set; }
    public NameInput Name { get; set; } = new(string.Empty, string.Empty);
    public string Email { get; set; } = string.Empty;
    public PhoneNumberInput Phone { get; set; } = new(string.Empty, string.Empty);
    public AddressInput Address { get; set; } = new();

    public CustomerInput WithId(string id)
    {
        Id = id;

        return this;
    }

    public CustomerEntity ToEntity() => CustomerEntity.From(this);
}
