using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;

namespace SmartLogis.API.Repository
{
    public class EstatusRepository : IEstatusRepository
    {
        public Task<bool> AddAsync(Estatus entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Estatus entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Estatus> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<Estatus?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Estatus entity)
        {
            throw new NotImplementedException();
        }
    }
}