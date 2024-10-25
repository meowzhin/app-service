using FwksLabs.Libs.Core.Attributes;
using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.Extensions;
using FwksLabs.ResumeService.Core.Resources.Common.Models;
using FwksLabs.ResumeService.Core.Resources.Customers.Inputs;
using FwksLabs.ResumeService.Core.Resources.Customers.Outputs;
using FwksLabs.ResumeService.Core.Resources.Orders;

namespace FwksLabs.ResumeService.Core.Resources.Customers;

[ObfuscateResource]
public sealed class CustomerEntity : Entity<int>
{
    required public NameModel Name { get; set; }
    required public string Email { get; set; }
    required public PhoneNumberModel Phone { get; set; }
    required public AddressModel Address { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = [];

    public static CustomerEntity From(CustomerInput input) => new()
    {
        Name = new()
        {
            First = input.Name.First,
            Last = input.Name.Last
        },
        Email = input.Email,
        Phone = new()
        {
            CountryCode = input.Phone.CountryCode,
            Number = input.Phone.Number
        },
        Address = new()
        {
            Street = input.Address.Street,
            Details = input.Address.Details,
            City = input.Address.City,
            StateProvince = input.Address.StateProvince,
            Country = input.Address.Country,
            ZipCode = input.Address.ZipCode
        }
    };

    public CustomerEntity Patch(CustomerInput input)
    {
        Name.First = input.Name.First;
        Name.Last = input.Name.Last;

        Email = input.Email;

        Phone.CountryCode = input.Phone.CountryCode;
        Phone.Number = input.Phone.Number;

        Address.Street = input.Address.Street;
        Address.Details = input.Address.Details;
        Address.City = input.Address.City;
        Address.StateProvince = input.Address.StateProvince;
        Address.Country = input.Address.Country;
        Address.ZipCode = input.Address.ZipCode;

        return this;
    }

    public CustomerOutput ToOutput() => new()
    {
        Id = this.EncodeId(),
        Name = new(Name.First, Name.Last),
        Email = Email,
        Phone = new(Phone.CountryCode, Phone.Number),
        Address = new()
        {
            Street = Address.Street,
            Details = Address.Details,
            City = Address.City,
            StateProvince = Address.StateProvince,
            Country = Address.Country,
            ZipCode = Address.ZipCode
        }
    };
}
