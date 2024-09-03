using FwksLab.AppService.Core.Inputs.Addresses;
using FwksLab.AppService.Core.Models;

namespace FwksLab.AppService.Core.Outputs.Addresses;

public record AddressOutput : NewAddressInput
{
    public static AddressOutput Transform(AddressModel ownedType) => new()
    {
        Street = ownedType.Street,
        Number = ownedType.Number,
        City = ownedType.City,
        State = ownedType.State,
        Country = ownedType.Country
    };
}