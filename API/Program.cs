using Entities.Models;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("*")
            .AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ExamenContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});


builder.Services.AddScoped<IViaje, ViajeService>();
builder.Services.AddScoped<IRutum, RutasService>();
builder.Services.AddScoped<IPasajeros, PasajeroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
