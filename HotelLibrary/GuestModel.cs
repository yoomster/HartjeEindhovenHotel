using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record GuestModel (
    int Id, 
    string FirstName, 
    string LastName
    );
