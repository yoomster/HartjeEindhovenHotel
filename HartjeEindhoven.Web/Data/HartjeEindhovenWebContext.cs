using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelLibrary;

namespace HartjeEindhoven.Web.Data
{
    public class HartjeEindhovenWebContext : DbContext
    {
        public HartjeEindhovenWebContext (DbContextOptions<HartjeEindhovenWebContext> options)
            : base(options)
        {
        }

        public DbSet<HotelLibrary.RoomModel> RoomModel { get; set; } = default!;
    }
}
