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
    Faker<RoomTypeModel>?_fakeRoomType;

    public Faker<GuestModel> GetCustomerGenerator()
    {
        //UseSeed for getting same fake data, useful for testing!!!
        //Randomizer.Seed = new Random(123);

        var id = 0;

        _fakeGuest = new Faker<GuestModel>()
            .UseSeed(123)
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.Zipcode, f => f.Address.ZipCode());
 
        return _fakeGuest;
    }

    public Faker<RoomTypeModel> GetRoomTypeGenerator()
    {
        var id = 0;

        _fakeRoomType = new Faker<RoomTypeModel>()
            .UseSeed(111)
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.Title, f => f.PickRandom<RoomTitleEnum>())
            .RuleFor(u => u.Description, f => f.Random.Words())
            .RuleFor(u => u.Price, f => f.Random.Int(30, 150))
            ;

            return _fakeRoomType;
    }


}