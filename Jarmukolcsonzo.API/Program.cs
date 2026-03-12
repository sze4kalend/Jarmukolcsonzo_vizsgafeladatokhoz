using Jarmukolcsonzo.API.Data;
using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<JKContext>(o => 
    o.UseMySql(
        builder.Configuration.GetConnectionString("JKDB"),
        ServerVersion.Parse("10.4.32-mariadb")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
