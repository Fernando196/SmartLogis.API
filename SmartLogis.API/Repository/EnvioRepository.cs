using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

    public Task<bool> DeleteAsync(Envio entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EnvioExists(string nombre)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EnvioExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Envio>> FindAsync(Expression<Func<Envio, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Envio> GetAllQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<Envio?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public Task<bool> UpdateAsync(Envio entity)
    {
        throw new NotImplementedException();
    }
}