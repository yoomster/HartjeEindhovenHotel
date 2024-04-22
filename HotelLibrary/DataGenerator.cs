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
    //Faker<RoomTypeModel> roomTypeFake;
    //public DataGenerator()
    //{
    //    Randomizer.Seed = new Random(123);

    //    roomTypeFake = new Faker<RoomTypeModel>()
    //        .RuleFor(u => u.Title, f => f.Name.Random.String())
    //        .RuleFor(u => u.Price, f => f.Random.Float(30, 250))
    //        .RuleFor(u => u.Description, f => f.Lorem);
    //}

    //public RoomTypeModel GenerateRoomType()
    //{
    //    return roomTypeFake.Generate();
    //}

    Faker<GuestModel> GuestFaker;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(123);

        GuestFaker = new Faker<GuestModel>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.Zipcode, f => f.Address.ZipCode());
    }

    public GuestModel GenerateGuest()
    {
        return GuestFaker.Generate();
    }
}