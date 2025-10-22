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
    public class EstatusRepository : IEstatusRepository
    {
        private readonly ApplicationDbContext _db;

        public EstatusRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Estatus estatus)
        {
            await _db.AddAsync(estatus);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Estatus estatus)
        {
            _db.Remove(estatus);
            return await SaveAsync();
        }

        public async Task<bool> EstatusExists(string nombre)
        {
            return await _db.Estatus.AnyAsync(estatus => estatus.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
        }

        public async Task<bool> EstatusExists(int id)
        {
            return await _db.Estatus.AnyAsync(Estatus => Estatus.IdEstatus == id);
        }

        public IQueryable<Estatus> GetAllQueryable()
        {
            return _db.Estatus.AsQueryable();
        }

        public async Task<Estatus?> GetByIdAsync(int id)
        {
            return await _db.Estatus.FirstOrDefaultAsync(estatus => estatus.IdEstatus == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateAsync(Estatus estatus)
        {
            _db.Estatus.Update(estatus);
            return await SaveAsync();
        }
    }
}