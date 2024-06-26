using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Cars.Services;
using VectoVia.Models.Cars;
using VectoVia.Models.KompaniaRents;
using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Models.KompaniaTaxi;
using VectoVia.Models.TaxiCars.Services;
using VectoVia.Models.TaxiCars;
using VectoVia.Models.Users.Services;
using VectoVia.Models.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString") //Ndrro emrin e stringut qitu per me connect to your database
));

builder.Services.AddDbContext<KompaniaTaxisDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddDbContext<CarsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddDbContext<TaxiCarsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddDbContext<KompaniaRentDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<KompaniaTaxiServices>();
builder.Services.AddTransient<CarServices>();
builder.Services.AddTransient<TaxiCarServices>();
builder.Services.AddTransient<KompaniaRentDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure CORS
app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

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

app.Run();
