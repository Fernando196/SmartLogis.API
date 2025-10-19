using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces
{
    public interface ITransportistaRepository : IRepositoryBase<Transportista>
    {
        Task<bool> TransportistaExists(string nombre);
        Task<bool> TransportistaExists(int id);
    }
}