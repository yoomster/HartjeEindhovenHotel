using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record RoomModel {
    public int Id { get; set; }
    public int RoomNr { get; set; }
    public RoomTypeModel RoomType { get; set; }

    //int Id,
    //string RoomNumber,
    //RoomTypeModel RoomTypeId
    }