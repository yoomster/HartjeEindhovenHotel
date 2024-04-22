using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary;

public record GuestModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
}


    //(
    //int Id, 
    //string FirstName, 
    //string LastName,
    //string StreetAddress,
    //string City,
    //string Zipcode
    //);
