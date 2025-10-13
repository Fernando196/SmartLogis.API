using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Middlewares;
using SmartLogis.API.Repository;
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

    public async Task<bool> CreateAsync(Cliente cliente)
    {
        if (await _clientRepository.ClienteExists(cliente.Nombre))
            throw new ApiException(400,"El cliente ya existe");
        if (await _clientRepository.RFCClienteExists(cliente.RFC))
            throw new ApiException(400,"La rfc del cliente ya existe");

        return await _clientRepository.AddAsync(cliente);
    }

    public async Task<bool> DeleteAsync(int idCliente)
    {
        var cli = await _clientRepository.GetByIdAsync(idCliente);

        if (cli == null)
            throw new ApiException(404,"El cliente no exsite");
        
        return await _clientRepository.DeleteAsync(cli);
    }

    public async Task<IEnumerable<Cliente>> FindAsync(FiltrosDto filtrosDto)
    {
        return await _clientRepository.FindAsync(c => c.IdEstatus == 1);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _clientRepository.GetAllAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        var cliente = await _clientRepository.GetByIdAsync(id);
        if (cliente == null)
            throw new ApiException(404,"No se encotro el cliente");

        return cliente;
    }

    public async Task<bool> UpdateAsync(int id, Cliente cliente)
    {
        if (await _clientRepository.ClienteExists(id))
            throw new ApiException(404,"No existe el cliente");

        cliente.IdCliente = id;
        var updateCliente = await _clientRepository.UpdateAsync(cliente);
        if (!updateCliente)
        {
            throw new ApiException(500,"Ocurrio un problema al actualizar el cliente");
        }
        return updateCliente;
    }
}