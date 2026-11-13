using Microsoft.EntityFrameworkCore;
using ServidorCondorRest.ec.edu.monster.modelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); // <-- AGREGA ESTA LÍNEA

builder.Services.AddDbContext<AerolineasCondorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
