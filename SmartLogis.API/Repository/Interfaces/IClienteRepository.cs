using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Repository.Interfaces;

public interface IClienteRepository: IReposityBase<Cliente>
{
    ICollection<Envio> GetEnviosByCliente(int idCliente);
    bool ClienteExists(string nombre);
    bool ClienteExists(int id);
}
