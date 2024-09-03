using FwksLab.AppService.Core.Models;

namespace FwksLab.AppService.Core.Inputs.Addresses;

public record NewAddressInput
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public AddressModel Transform() => new()
    {
        Street = Street,
        Number = Number,
        City = City,
        State = State,
        Country = Country
    };
}