using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces
{
    public interface IRutasRepository : IRepositoryBase<Rutas>
    {
        Task<bool> RutaExists(int id);
        Task<bool> RutaExists(string nombre);
        Task<int> CountAsync();
    }
}