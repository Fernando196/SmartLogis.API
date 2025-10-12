using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartLogis.API.Data;
using SmartLogis.API.Models;
using SmartLogis.API.Repository.IRepository;

namespace SmartLogis.API.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _db;

    public ClienteRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool ClienteExists(string nombre)
    {
        return _db.Cliente.Any(cliente => cliente.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
    }

    public bool ClienteExists(int id)
    {
        return _db.Cliente.Any(cliente => cliente.IdCliente == id);
    }

    public bool CreateCliente(Cliente cliente)
    {
        cliente.CreationDate = DateTime.Now;
        cliente.ModificationDate = DateTime.Now;
        _db.Cliente.Add(cliente);
        return Save();
    }

    public bool DeleteCliente(Cliente cliente)
    {
        _db.Cliente.Remove(cliente);
        return Save();
    }

    public Cliente? GetCliente(int id)
    {
        return _db.Cliente.FirstOrDefault(cliente => cliente.IdCliente == id);
    }

    public ICollection<Cliente> GetClientes()
    {
        return _db.Cliente.OrderBy(cliente => cliente.Nombre).ToList();
    }

    public ICollection<Envio> GetEnviosByCliente(int idCliente)
    {
        return _db.Envio.Where(envio => envio.IdCliente == idCliente).ToList();
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }

    public bool UpdateCliente(Cliente cliente)
    {
        cliente.ModificationDate = DateTime.Now;
        _db.Cliente.Update(cliente);
        return Save();
    }
}