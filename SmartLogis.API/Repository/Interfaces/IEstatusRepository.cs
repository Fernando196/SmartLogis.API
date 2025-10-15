using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces
{
    public interface IEstatusRepository:IRepositoryBase<Estatus>
    {
        Task<bool> EnvioExists(string nombre);
        Task<bool> EnvioExists(int id);
    }
}