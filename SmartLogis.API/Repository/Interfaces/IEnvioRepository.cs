using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces;

public interface IEnvioRepository : IRepositoryBase<Envio>
{
    Task<bool> EnvioExists(string nombre);
    Task<bool> EnvioExists(int id);
}