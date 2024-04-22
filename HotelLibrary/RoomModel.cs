using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record RoomModel(
    int Id,
    string RoomNumber, 
    RoomTypeModel RoomTypeId
    );