using Microsoft.EntityFrameworkCore;
using webApiRest.Models.Context;

var builder = WebApplication.CreateBuilder(args);

//Agregar referencia para la conexión de la base de datos

var connectionString = builder.Configuration.GetConnectionString("InstitutoTich3");
builder.Services.AddDbContext<EstadosContext>(x => x.UseSqlServer(connectionString));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
