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

namespace SmartLogis.API.Services;

public class TransportistaService : ITransportistaService
{
    private readonly ITransportistaRepository _transportistaRepository;
    private readonly IEstatusRepository _estatusRepository;

    public TransportistaService(ITransportistaRepository transportistaRepository, IEstatusRepository estatusRepository)
    {
        _transportistaRepository = transportistaRepository;
        _estatusRepository = estatusRepository;
    }

    public async Task<Transportista> CreateAsync(Transportista transportista)
    {
        if (string.IsNullOrWhiteSpace(transportista.Nombre))
            throw new ApiException(400, "El nombre del transportista es requerido");
        
        if(await _transportistaRepository.TransportistaExists(transportista.Nombre))
        {
            throw new ApiException(400, "Ya existe un transportista con el mismo nombre");
        }

        if(!await _estatusRepository.EnvioExists(transportista.IdEstatus))
        {
            throw new ApiException(400, "El estatus proporcionado no existe");
        }

        var transportistaCreated = await _transportistaRepository.AddAsync(transportista);
        if (!transportistaCreated)
        {
            throw new ApiException(500, "Error al crear el transportista");
        }
        return transportista;
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _transportistaRepository.TransportistaExists(id))
        {
            throw new ApiException(404, "El transportista no existe");
        }
        var transportista = await _transportistaRepository.GetByIdAsync(id);
        if (transportista == null)
        {
            throw new ApiException(404, "El transportista no existe");
        }

        await _transportistaRepository.DeleteAsync(transportista);
    }

    public async Task<IEnumerable<Transportista>> GetAllAsync(Dictionary<string, Filter>? filters)
    {
        var query = _transportistaRepository.GetAllQueryable();
        if (filters != null)
        {
            query = query.ApplyFilters(filters);
        }
        return await query.ToListAsync();
    }

    public Task<Transportista?> GetByIdAsync(int id)
    {
        var transportista = _transportistaRepository.GetByIdAsync(id);
        if (transportista == null)
        {
            throw new ApiException(404, "El transportista no existe");
        }
        return transportista;
    }

    public async Task UpdateAsync(int id, Transportista transportista)
    {
        if (!await _transportistaRepository.TransportistaExists(id))
        {
            throw new ApiException(404, "El transportista no existe");
        }

        transportista.IdTransportista = id;
        var transportistaUpdated = await _transportistaRepository.UpdateAsync(transportista);
        if (!transportistaUpdated)
        {
            throw new ApiException(500, "Error al actualizar el transportista");
        }
    }
}