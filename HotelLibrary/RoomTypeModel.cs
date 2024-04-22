using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record RoomTypeModel {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }

    //int Id,
    //string Title,
    //string Description,
    //float Price
}
