using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Helpers;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _db;

    public ClienteRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<bool> ClienteExists(string nombre)
    {
        return _db.Cliente.AnyAsync(cliente => cliente.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
    }

    public Task<bool> ClienteExists(int id)
    {
        return _db.Cliente.AnyAsync(cliente => cliente.IdCliente == id);
    }

    public Task<bool> RFCClienteExists(string rfc)
    {
        return _db.Cliente.AnyAsync(cliente => cliente.RFC == rfc);
    }
    
    public async Task<ICollection<Envio>> GetEnviosByCliente(int idCliente)
    {
        return await _db.Envio.Where(envio => envio.IdCliente == idCliente).ToListAsync();
    }

    public IQueryable<Cliente> GetAllQueryable()
    {
        return _db.Cliente.AsQueryable();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _db.Cliente.FirstOrDefaultAsync(c => c.IdCliente == id);
    }

    public async Task<bool> AddAsync(Cliente entity)
    {
        _db.Cliente.Add(entity);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Cliente entity)
    {
        _db.Cliente.Update(entity);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(Cliente entity)
    {
        _db.Cliente.Remove(entity);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() >= 0 ? true : false;
    }
}