using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.Interfaces;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Services
{
    public class DetalleEnvioService : IDetalleEnvioService
    {
        private IEnvioRepository _envioRepository;
        private IEstatusRepository _estatusRepository;

        public DetalleEnvioService(IEnvioRepository envioRepository, IEstatusRepository estatusRepository)
        {
            _envioRepository = envioRepository;
            _estatusRepository = estatusRepository;
        }

        public Task<DetallesEnvio> CreateAsync(DetallesEnvio detallEnvio)
        {
            // Validacion si existe el envio
            
            // Validacion si existe el transportista

            // Validacion si existe la ruta
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DetallesEnvio>> GetAllAsync(Dictionary<string, Filter>? body)
        {
            throw new NotImplementedException();
        }

        public Task<DetallesEnvio?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, DetallesEnvio detallEnvio)
        {
            throw new NotImplementedException();
        }
    }
}