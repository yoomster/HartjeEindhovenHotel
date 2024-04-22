using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record BookingModel(
     int Id, 
     RoomModel Room,
     GuestModel guest,
     DateOnly StartDate,
     DateOnly EndDate,
     bool CheckedIn,
     int TotalCost
);
