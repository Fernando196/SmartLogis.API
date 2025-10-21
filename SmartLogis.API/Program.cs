using Mapster;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API;
using SmartLogis.API.Data;
using SmartLogis.API.Mapping;
using SmartLogis.API.Repository;
using SmartLogis.API.Repository.Interfaces;
using SmartLogis.API.Services;
using SmartLogis.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("ConexionSql");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionString));


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IEstatusRepository, EstatusRepository>();
builder.Services.AddScoped<IEstatusService, EstatusService>();

builder.Services.AddScoped<ITransportistaRepository, TransportistaRepository>();
builder.Services.AddScoped<ITransportistaService, TransportistaService>();

builder.Services.AddScoped<IRutasRepository, RutasRepository>();
builder.Services.AddScoped<IRutasService, RutasService>();

var typeAdapterConfig = new TypeAdapterConfig();
ClienteMapping.RegisterMappings(typeAdapterConfig);

builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();