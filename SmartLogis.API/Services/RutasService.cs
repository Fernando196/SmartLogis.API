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
    public class RutasService : IRutasService
    {
        private readonly IRutasRepository _rutasRepository;

        public RutasService(IRutasRepository rutasRepository)
        {
            _rutasRepository = rutasRepository;
        }


        public async Task<Rutas> CreateAsync(Rutas ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta.CodigoRuta))
                throw new ApiException(400, "El código de la ruta es requerido");

            if (string.IsNullOrWhiteSpace(ruta.Origen))
                throw new ApiException(400, "El origen de la ruta es requerido");

            if (string.IsNullOrWhiteSpace(ruta.Destino))
                throw new ApiException(400, "El destino de la ruta es requerido");

            if(!(ruta.CodigoRuta == "" || ruta.CodigoRuta == null))
            {
                throw new ApiException(400, "El código de la ruta debe ser generado automáticamente");
            }

            ruta.CodigoRuta = await GenerarCodigoRutaAsync();
            var rutaCreated = await _rutasRepository.AddAsync(ruta);
            if (!rutaCreated)
            {
                throw new ApiException(500, "Error al crear la ruta");
            }
            return ruta;
        }

        public async Task DeleteAsync(int id)
        {
            var ruta = await _rutasRepository.GetByIdAsync(id);
            if (ruta == null)
            {
                throw new ApiException(404, "La ruta no existe");
            }
            await _rutasRepository.DeleteAsync(ruta);
        }

        public async Task<string> GenerarCodigoRutaAsync()
        {
            int count = await _rutasRepository.CountAsync() + 1;
            string codigoRuta = $"RUTA-${DateTime.UtcNow:yyyyMMdd}-{count:D3}";
            return codigoRuta;
        }

        public async Task<IEnumerable<Rutas>> GetAllAsync(Dictionary<string, Filter>? filters)
        {
            var query = _rutasRepository.GetAllQueryable();
            if (filters != null)
            {
                query = query.ApplyFilters(filters);
            }
            return await query.ToListAsync();
        }

        public Task<Rutas?> GetByIdAsync(int id)
        {
            return _rutasRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Rutas ruta)
        {
            if (!await _rutasRepository.RutaExists(id))
            {
                throw new ApiException(404, "La ruta no existe");
            }
            ruta.IdRuta = id;
            await _rutasRepository.UpdateAsync(ruta);
        }
    }
}