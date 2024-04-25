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
    Faker<RoomType>?_fakeRoomType;
    Faker<RoomModel>? _fakeRoom;

    public Faker<GuestModel> GetCustomerGenerator()
    {
        //UseSeed for getting same fake data, useful for testing!!!

        var id = 0;

        _fakeGuest = new Faker<GuestModel>()
            .UseSeed(111)
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.Zipcode, f => f.Address.ZipCode());
 
        return _fakeGuest;
    }

    public Faker<RoomModel> GetRoomGenerator()
    {
        //var fakeRoomType = GetRoomTypeGenerator();

        var id = 0;
        var roomNr = 101;

        _fakeRoom = new Faker<RoomModel>()
            .UseSeed(333)
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.RoomNr, f => ++roomNr);

        return _fakeRoom;
    }

    //hard code the room types, 
    //public Faker<RoomType> GetRoomTypeGenerator()
    //{
    //    var id = 0;

    //    _fakeRoomType = new Faker<RoomType>()
    //        //.UseSeed(222)
    //        .RuleFor(u => u.Id, f => ++id)
    //        .RuleFor(u => u.Title, f => f.PickRandom<RoomTitleEnum>())
    //        .RuleFor(u => u.Description, f => f.Random.Words())
    //        .RuleFor(u => u.Price, f => f.Random.Int(30, 150));

    //    return _fakeRoomType;
    //}
}