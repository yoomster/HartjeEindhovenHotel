using HotelLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HartjeEindhoven.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HartjeEindhovenWebContext>(options =>
    options.UseSqlServer("Server=YOOMSTER\\SQLEXPRESS;Database=HartjeEindhovenDb;Trusted_Connection=True;Encrypt=False"));
builder.Services.AddTransient<DataGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    // Resolve your DbContext within the scope
    var ctx = scope.ServiceProvider.GetRequiredService<HartjeEindhovenWebContext>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.Run();
