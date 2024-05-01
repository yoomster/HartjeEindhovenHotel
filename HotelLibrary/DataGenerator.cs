using Bogus;
using HotelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public class DataGenerator
{
    Faker<Guest>? _fakeGuest;
    Faker<Room>? _fakeRoom;
    RoomType? _roomType;


    public Faker<Guest> GetCustomerGenerator()
    {
        //UseSeed for getting same fake data, useful for testing!!!

        var id = 0;

        _fakeGuest = new Faker<Guest>()
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.Zipcode, f => f.Address.ZipCode());
 
        return _fakeGuest;
    }

    public Faker<Room> GetRoomGenerator()
    {
        var id = 0;
        // 101 if roomtype = 1, 201 if roomt=2 and 301 if 3
        var roomNr = 101;

        _fakeRoom = new Faker<Room>()
            .RuleFor(u => u.Id, f => ++id)
            .RuleFor(u => u.RoomNr, f => ++roomNr)
            .RuleFor(u => u.RoomTypeId, f => 1); 
        

        return _fakeRoom;
    }

    public RoomType GetRoomTypeGenerator()
    {
        var id = 0;

        _roomType = new RoomType
        {
            Id = 1,
            Title = "Kingsize Bedroom",
            Description = "A room with a king-size bed.",
            Price = 60M
        };

        //new RoomType
        //{
        //    Title = "Two Queen Size Beds",
        //    Description = "A room with two queen-size beds",
        //    Price = 100M
        //},

        //new RoomType
        //{
        //    Title = "Executive Suite",
        //    Description = "Two rooms, each with a king-size bed",
        //    Price = 150M
        //}
        //);
        return _roomType;
       }
}