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

builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IEnvioService, EnvioService>();

var typeAdapterConfig = new TypeAdapterConfig();
ClienteMapping.RegisterMappings(typeAdapterConfig);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SmartLogis API",
        Version = "v1",
        Description = "API para el sistema de gestión logística SmartLogis",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "SmartLogis Team"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartLogis API v1");
        c.RoutePrefix = "swagger"; // Para acceder desde /swagger
    });
}

app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();