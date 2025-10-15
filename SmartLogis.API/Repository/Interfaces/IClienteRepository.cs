using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces;

public interface IClienteRepository : IRepositoryBase<Cliente>
{
    Task<ICollection<Envio>> GetEnviosByCliente(int idCliente);
    Task<bool> ClienteExists(string nombre);
    Task<bool> ClienteExists(int id);
    Task<bool> RFCClienteExists(string rfc);
}
