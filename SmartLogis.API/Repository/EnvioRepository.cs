using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository;
public class EnvioRepository : IEnvioRepository
{
    private readonly ApplicationDbContext _db;

    public EnvioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(Envio entity)
    {
        _db.Envio.Add(entity);
        return await SaveAsync();
    }

    public Task<int> CountAsync()
    {
        return _db.Envio.CountAsync();
    }

    public async Task<bool> DeleteAsync(Envio entity)
    {
        _db.Envio.Remove(entity);
        return await SaveAsync();
    }

    public Task<bool> EnvioExists(string numeroGuia)
    {
        return _db.Envio.AnyAsync(envio => envio.NumeroGuia == numeroGuia);
    }

    public Task<bool> EnvioExists(int id)
    {
        return _db.Envio.AnyAsync(envio => envio.IdEnvio == id);
    }

    public IQueryable<Envio> GetAllQueryable()
    {
        return _db.Envio.Include(e => e.Cliente).AsQueryable();
    }

    public async Task<Envio?> GetByIdAsync(int id)
    {
        return await _db.Envio
            .Where(envio => envio.IdEnvio == id)
            .Select(e => new Envio
            {
                IdEnvio = e.IdEnvio,
                IdEstatus = e.IdEstatus,
                IdCliente = e.IdCliente,
                NumeroGuia = e.NumeroGuia,
                Origen = e.Origen,
                Destino = e.Destino,
                Peso = e.Peso,
                Volumen = e.Volumen,
                Cliente = new Cliente
                {
                    IdCliente = e.Cliente.IdCliente,
                    Nombre = e.Cliente.Nombre,
                }
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public async Task<bool> UpdateAsync(Envio entity)
    {
        _db.Envio.Update(entity);
        return await SaveAsync();
    }
}