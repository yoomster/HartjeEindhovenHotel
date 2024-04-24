using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelLibrary;
using Microsoft.EntityFrameworkCore.Design;

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

    public class BloggingContextFactory : IDesignTimeDbContextFactory<HartjeEindhovenWebContext>
    {
        public HartjeEindhovenWebContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HartjeEindhovenWebContext>();
            optionsBuilder.UseSqlServer("Server=YOOMSTER\\SQLEXPRESS;Database=hotel_db;Trusted_Connection=True;Encrypt=False");

            return new HartjeEindhovenWebContext(optionsBuilder.Options);
        }
    }
}
