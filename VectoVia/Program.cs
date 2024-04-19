using Microsoft.EntityFrameworkCore;
using VectoVia.Models.Users;
using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Models.Users.Services;
using VectoVia.Models.KompaniaTaxi;
using VectoVia.Models.KompaniaRents;
using VectoVia.Models.KompaniaRents.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString") //Ndrro emrin e stringut qitu per me connect to your database
));

builder.Services.AddDbContext<KompaniaTaxisDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddDbContext<KompaniaRentDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AlpLaptopString")
));

builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<KompaniaTaxiServices>();
builder.Services.AddTransient<KompaniaRentServices>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 



var app = builder.Build();

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
