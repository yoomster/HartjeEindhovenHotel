using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record BookingModel
{
    public int Id { get; set; }
    public RoomModel RoomId { get; set; }
    public GuestModel GuestId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool CheckedIn { get; set; }
    public float TotalCost { get; set; }


    //    int Id, 
    //     RoomModel RoomId,
    //     GuestModel GuestId,
    //     DateOnly StartDate,
    //     DateOnly EndDate,
    //     bool CheckedIn,
    //     float TotalCost
}