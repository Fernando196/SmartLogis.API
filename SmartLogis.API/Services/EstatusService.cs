using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartLogis.API.Helpers;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Middlewares;
using SmartLogis.API.Repository.Interfaces;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Services
{
    public class EstatusService : IEstatusService
    {
        private readonly IEstatusRepository _estatusRepository;

        public EstatusService(IEstatusRepository estatusRepository)
        {
            _estatusRepository = estatusRepository;
        }

        public async Task<Estatus> CreateAsync(Estatus estatus)
        {
            if (string.IsNullOrWhiteSpace(estatus.Nombre))
            {
                throw new ApiException(400, "El nombre es obligatorio");
            }

            var createdEstatus = await _estatusRepository.AddAsync(estatus);
            return estatus;
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _estatusRepository.EnvioExists(id))
                throw new ApiException(404, "No existe el estatus a eliminar");

            var estatus = await _estatusRepository.GetByIdAsync(id);
            if (estatus == null) throw new ApiException(404, "No se encontro el estatus a eliminar");

            await _estatusRepository.DeleteAsync(estatus);
        }

        public async Task<IEnumerable<Estatus>> GetAllAsync(Dictionary<string, Filter>? filters)
        {
            var query = _estatusRepository.GetAllQueryable();
            if (filters != null)
                query = query.ApplyFilters(filters);
            return await query.ToListAsync();
        }

        public async Task<Estatus?> GetByIdAsync(int id)
        {
            return await _estatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Estatus estatus)
        {
            if (string.IsNullOrWhiteSpace(estatus.Nombre))
                throw new ApiException(400, "El nombre es requeridol");
            if (!await _estatusRepository.EnvioExists(id))
                throw new ApiException(404, "No existe el estatus a buscar");

            estatus.IdEstatus = id;
            await _estatusRepository.UpdateAsync(estatus);
        }
    }
}