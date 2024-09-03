using FwksLab.AppService.Core.Entities;
using FwksLab.AppService.Core.Inputs.Addresses;

namespace FwksLab.AppService.Core.Inputs.Customers;

public record CustomerInput
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public NewAddressInput Address { get; set; } = new();

    public CustomerEntity Transform() => new()
    {
        Name = Name,
        Email = Email,
        Phone = Phone,
        Profession = Profession,
        Address = Address.Transform()
    };

    public CustomerEntity Patch(CustomerEntity entity)
    {
        entity.Patch(
            Name,
            Email,
            Phone,
            Profession,
            Address.Transform());

        return entity;
    }
}
