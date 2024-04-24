using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelLibrary;
using Microsoft.EntityFrameworkCore.Design;
using Bogus;


namespace HartjeEindhoven.Web.Data
{
    public class HartjeEindhovenWebContext : DbContext
    {
        private readonly DataGenerator _dataGenerator;

        public HartjeEindhovenWebContext (DbContextOptions<HartjeEindhovenWebContext> options,
            DataGenerator dataGenerator)
            : base(options)
        {
            this._dataGenerator = dataGenerator;
        }

        public DbSet<HotelLibrary.RoomModel> Rooms { get; set; } = default!;
        public DbSet<HotelLibrary.RoomTypeModel> RoomTypes { get; set; } = default!;
        public DbSet<HotelLibrary.GuestModel> Guests { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GuestModel>()
                .HasData(_dataGenerator.GetCustomerGenerator().Generate(50));

            builder.Entity<RoomTypeModel>()
                .HasData(_dataGenerator.GetRoomTypeGenerator().Generate(15));
        }
    }

    //public class BloggingContextFactory : IDesignTimeDbContextFactory<HartjeEindhovenWebContext>
    //{
    //    public HartjeEindhovenWebContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<HartjeEindhovenWebContext>();
    //        optionsBuilder.UseSqlServer("Server=YOOMSTER\\SQLEXPRESS;Database=hotel_db;Trusted_Connection=True;Encrypt=False");

    //        return new HartjeEindhovenWebContext(optionsBuilder.Options);
    //    }
    //}

}
