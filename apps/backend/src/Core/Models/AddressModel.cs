namespace FwksLab.AppService.Core.Models;

public sealed record AddressModel
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public void Patch(AddressModel address)
    {
        Street = address.Street;
        Number = address.Number;
        City = address.City;
        State = address.State;
        Country = address.Country;
    }
}
