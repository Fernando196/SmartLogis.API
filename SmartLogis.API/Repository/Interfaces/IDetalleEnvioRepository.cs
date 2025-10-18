using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces
{
    public interface IDetalleEnvioRepository:IRepositoryBase<DetallesEnvio>
    {
        Task<bool> DetalleEnvioExists(int idDetalle);
    }
}