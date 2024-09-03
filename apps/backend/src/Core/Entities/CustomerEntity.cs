using FwksLab.AppService.Core.Models;
using FwksLab.Libs.Core.Entities;

namespace FwksLab.AppService.Core.Entities;

public sealed class CustomerEntity : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public AddressModel Address { get; set; } = new();

    public CustomerEntity Patch(
        string name,
        string email,
        string phone,
        string profession,
        AddressModel address)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Profession = profession;

        Address.Patch(address);

        return this;
    }
}
