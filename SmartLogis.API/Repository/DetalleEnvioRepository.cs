using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository;

public class DetalleEnvioRepository : IDetalleEnvioRepository
{
    private ApplicationDbContext _db;

    public DetalleEnvioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(DetallesEnvio detalleEnvio)
    {
        await _db.DetallesEnvio.AddAsync(detalleEnvio);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(DetallesEnvio detalleEnvio)
    {
        _db.Remove(detalleEnvio);
        return await SaveAsync(); 
    }

    public async Task<bool> DetalleEnvioExists(int idDetalle)
    {
        return await _db.DetallesEnvio.AnyAsync(d => d.IdDetalle == idDetalle);
    }

    public IQueryable<DetallesEnvio> GetAllQueryable()
    {
        return _db.DetallesEnvio.AsQueryable();
    }

    public async Task<DetallesEnvio?> GetByIdAsync(int id)
    {
        return await _db.DetallesEnvio.FirstOrDefaultAsync(d => d.IdDetalle == id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(DetallesEnvio detalleEnvio)
    {
        _db.DetallesEnvio.Update(detalleEnvio);
        return await SaveAsync();
    }
}