using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using SmartLogis.API.Helpers;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Middlewares;
using SmartLogis.API.Repository.Interfaces;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly IEnvioRepository _envioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEstatusRepository _estatusRepository;

        public EnvioService(IEnvioRepository envioRepository,IClienteRepository clienteRepository, IEstatusRepository estatusRepository)
        {
            _envioRepository = envioRepository;
            _clienteRepository = clienteRepository;
            _estatusRepository = estatusRepository;
        }

        public async Task<Envio> CreateAsync(Envio envio)
        {
            if (await _envioRepository.EnvioExists(envio.NumeroGuia))
                throw new ApiException(400, "El numero de guia ya existe");
            if (!await _clienteRepository.ClienteExists(envio.IdCliente))
                throw new ApiException(400, "El cliente no existe");
            if (!await _estatusRepository.EstatusExists(envio.IdEstatus))
                throw new ApiException(400, "El estatus no existe");

            if (string.IsNullOrWhiteSpace(envio.Origen))
                throw new ApiException(400, "El origen es obligatorio");
            if (string.IsNullOrWhiteSpace(envio.Destino))
                throw new ApiException(400, "El destino es obligatorio");

            if (envio.Peso <= 0)
                throw new ApiException(400, "El peso debe ser mayor a cero");
            if (envio.Volumen <= 0)
                throw new ApiException(400, "El volumen debe ser mayor a cero");

            if (envio.FechaSalida != null && envio.FechaSalida < DateTime.UtcNow)
                throw new ApiException(400, "La fecha de salida no puede ser menor a la fecha actual");

            envio.NumeroGuia = await GenerarNumeroGuiaAsync();

            var createdEnvio = await _envioRepository.AddAsync(envio);
            if (!createdEnvio)
            {
                throw new ApiException(500, "Ocurrio un problema al crear el envio");
            }
            return envio;
        }

        public async Task DeleteAsync(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null)
                throw new ApiException(404, "El envio no existe");
            
            await _envioRepository.DeleteAsync(envio);
        }

        public async Task<string> GenerarNumeroGuiaAsync()
        {
            int count = await _envioRepository.CountAsync() + 1;
            string numeroGuia = $"SL-{DateTime.UtcNow:yyyyMMdd}-{count:D4}";
            return numeroGuia;
        }

        public async Task<IEnumerable<Envio>> GetAllAsync(Dictionary<string, Filter>? filters)
        {
            var query = _envioRepository.GetAllQueryable();
            if (filters != null)
                query = query.ApplyFilters(filters);
            return await query.ToListAsync();
        }

        public async Task<Envio?> GetByIdAsync(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null)
                throw new ApiException(404, "El envio no existe");
            return envio;
        }

        public async Task UpdateAsync(int id, Envio envio)
        {
            if (!await _envioRepository.EnvioExists(id))
                throw new ApiException(404, "El envio no existe");

            envio.IdEnvio = id;
            var updated = await _envioRepository.UpdateAsync(envio);
            if (!updated)
            {
                throw new ApiException(500, "Ocurrio un problema al actualizar el envio");
            }
        }
    }
}