using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartLogis.API.Helpers;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Middlewares;
using SmartLogis.API.Repository.Interfaces;
using SmartLogis.API.Services.Interfaces;

namespace SmartLogis.API.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clientRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clientRepository = clienteRepository;
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        // Validaciones de negocio
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ApiException(400, "El nombre del cliente es requerido");

        if (string.IsNullOrWhiteSpace(cliente.RFC))
            throw new ApiException(400, "El RFC del cliente es requerido");

        // Verificar duplicados
        if (await _clientRepository.ClienteExists(cliente.Nombre))
            throw new ApiException(400, "Ya existe un cliente con ese nombre");
            
        if (await _clientRepository.RFCClienteExists(cliente.RFC))
            throw new ApiException(400, "Ya existe un cliente con ese RFC");

        var createdCliente = await _clientRepository.AddAsync(cliente);
        if (!createdCliente)
        {
            throw new ApiException(500, "Ocurrio un problema al crear el cliente");
        }
        return cliente;
    }

    public async Task DeleteAsync(int idCliente)
    {
        var cli = await _clientRepository.GetByIdAsync(idCliente);

        if (cli == null)
            throw new ApiException(404, "El cliente no exsite");

        await _clientRepository.DeleteAsync(cli);
    }
    
    public async Task<IEnumerable<Cliente>> GetAllAsync(Dictionary<string, Filter>? filters)
    {
        try
        {
            var query = _clientRepository.GetAllQueryable();
            if(filters != null)
                query = query.ApplyFilters(filters);
            return await query.ToListAsync();
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return new List<Cliente>();
        }
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        var cliente = await _clientRepository.GetByIdAsync(id);
        if (cliente == null)
            throw new ApiException(404,"No se encotro el cliente");

        return cliente;
    }

    public async Task<ICollection<Envio>> GetEnviosByCliente(int idCliente)
    {
        if(!await _clientRepository.ClienteExists(idCliente))
        {
            throw new ApiException(404, "El cliente no existe");
        }
        return await _clientRepository.GetEnviosByCliente(idCliente);
    }

    public async Task UpdateAsync(int id, Cliente cliente)
    {
        if (!await _clientRepository.ClienteExists(id))
            throw new Exception("El cliente no existe");

        cliente.IdCliente = id;
        var updateCliente = await _clientRepository.UpdateAsync(cliente);
        if (!updateCliente)
        {
            throw new Exception("Error al actualizar el cliente");
        }
    }
}