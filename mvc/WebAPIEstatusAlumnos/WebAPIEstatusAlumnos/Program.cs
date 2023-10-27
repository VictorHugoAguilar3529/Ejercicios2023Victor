using Microsoft.EntityFrameworkCore;
using WebAPIEstatusAlumnos.Models.Context;
using WebAPIEstatusAlumnos.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:58644").AllowAnyMethod().AllowAnyHeader();
    });
});

//Agregar referencia para la conexiín de la base de datos
var connectionString = builder.Configuration.GetConnectionString("institutoTich3");
builder.Services.AddDbContext<EstatusContext>(x => x.UseSqlServer(connectionString));

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

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
