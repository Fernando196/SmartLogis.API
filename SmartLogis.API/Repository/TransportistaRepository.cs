using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository
{
    public class TransportistaRepository : ITransportistaRepository
    {
        private ApplicationDbContext _db;

        public TransportistaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Transportista transportista)
        {
            await _db.Transportista.AddAsync(transportista);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Transportista transportista)
        {
            _db.Transportista.Remove(transportista);
            return await SaveAsync();
        }

        public IQueryable<Transportista> GetAllQueryable()
        {
            return _db.Transportista.AsQueryable();
        }

        public async Task<Transportista?> GetByIdAsync(int id)
        {
            return await _db.Transportista.FirstOrDefaultAsync(t => t.IdTransportista == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }

        public async Task<bool> TransportistaExists(string nombre)
        {
            return await _db.Transportista.AnyAsync(t => t.Nombre.Trim().ToLower() == nombre.Trim().ToLower());
        }

        public async Task<bool> TransportistaExists(int id)
        {
            return await _db.Transportista.AnyAsync(t => t.IdTransportista == id);
        }

        public Task<bool> UpdateAsync(Transportista transportista)
        {
            _db.Transportista.Update(transportista);
            return SaveAsync();
        }
    }
}