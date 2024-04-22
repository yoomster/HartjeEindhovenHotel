using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record RoomTypeModel(
    int Id,
    string Title,
    string Description,
    int Price
);
