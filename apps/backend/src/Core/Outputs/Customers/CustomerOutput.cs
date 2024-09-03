using FwksLab.AppService.Core.Entities;
using FwksLab.AppService.Core.Inputs.Customers;
using FwksLab.AppService.Core.Outputs.Addresses;

namespace FwksLab.AppService.Core.Outputs.Customers;

public record CustomerOutput : CustomerInput
{
    public Guid Id { get; set; }

    public static CustomerOutput Transform(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Email = entity.Email,
        Phone = entity.Phone,
        Profession = entity.Profession,
        Address = AddressOutput.Transform(entity.Address)
    };
}