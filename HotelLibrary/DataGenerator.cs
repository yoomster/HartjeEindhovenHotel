using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public class DataGenerator
{
    Faker<GuestModel>?_fakeGuest;


    public Faker<GuestModel> GetCustomerGenerator()
    {
        //UseSeed to always get the same fake data, useful for testing!!!
        //var id = 0;

        _fakeGuest = new Faker<GuestModel>()
            .UseSeed(123)
            //.RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.Zipcode, f => f.Address.ZipCode());
 
        return _fakeGuest;
    }
}