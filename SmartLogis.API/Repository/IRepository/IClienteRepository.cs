using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.IRepository;

public interface IClienteRepository
{
    ICollection<Cliente> GetClientes();
    Cliente? GetCliente(int id);
    ICollection<Envio> GetEnviosByCliente(int idCliente);
    bool ClienteExists(string nombre);
    bool ClienteExists(int id);
    bool CreateCliente(Cliente cliente);
    bool UpdateCliente(Cliente cliente);
    bool DeleteCliente(Cliente cliente);
    bool Save();
}
