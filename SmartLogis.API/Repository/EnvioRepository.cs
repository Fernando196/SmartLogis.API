using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
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
        return _db.Envio.AsQueryable();
    }

    public async Task<Envio?> GetByIdAsync(int id)
    {
        return await _db.Envio.FirstOrDefaultAsync(envio => envio.IdEnvio == id);
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