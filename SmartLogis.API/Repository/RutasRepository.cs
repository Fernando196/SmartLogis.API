using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository;
public class RutasRepository : IRutasRepository
{
    private ApplicationDbContext _db;

    public RutasRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(Rutas ruta)
    {
        await _db.Rutas.AddAsync(ruta);
        return await SaveAsync();
    }

    public Task<bool> DeleteAsync(Rutas ruta)
    {
        _db.Rutas.Remove(ruta);
        return SaveAsync();
    }

    public IQueryable<Rutas> GetAllQueryable()
    {
        return _db.Rutas.AsQueryable();
    }

    public Task<Rutas?> GetByIdAsync(int id)
    {
        return _db.Rutas.FirstOrDefaultAsync(r => r.IdRuta == id);
    }

    public Task<bool> RutaExists(int id)
    {
        return _db.Rutas.AnyAsync(r => r.IdRuta == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public Task<bool> UpdateAsync(Rutas ruta)
    {
        _db.Rutas.Update(ruta);
        return SaveAsync();
    }
}