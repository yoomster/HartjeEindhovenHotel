using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record Booking
{
    public int BookingId { get; set; }
    public Room RoomId { get; set; }
    public Guest GuestId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool CheckedIn { get; set; }
    public decimal TotalCost { get; set; }
}