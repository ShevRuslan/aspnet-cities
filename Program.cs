using CitiesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<CitiesContext>(options =>
    options.UseSqlServer(con));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.Run();
