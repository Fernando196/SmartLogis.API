using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public EnvioService(IEnvioRepository envioRepository,IClienteRepository clienteRepository)
        {
            _envioRepository = envioRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Envio> CreateAsync(Envio envio)
        {
            if (string.IsNullOrWhiteSpace(envio.NumeroGuia))
                throw new ApiException(400, "El numero de guia ya existe");
            if (!await _clienteRepository.ClienteExists(envio.IdCliente))
                throw new ApiException(400, "El cliente no existe");

            var createdEnvio = await _envioRepository.AddAsync(envio);
            if (!createdEnvio)
            {
                throw new ApiException(500, "Ocurrio un problema al crear el envio");
            }
            return envio;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Envio>> GetAllAsync(Dictionary<string, Filter> body)
        {
            throw new NotImplementedException();
        }

        public Task<Envio?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Envio envio)
        {
            throw new NotImplementedException();
        }
    }
}