using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;

namespace SmartLogis.API.Mapping
{
    public class ClienteMapping
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<Cliente, ClienteDto>().TwoWays();
            config.NewConfig<Cliente, CreateClienteDto>().TwoWays();
            config.NewConfig<Cliente, UpdateClienteDto>().TwoWays();
        }
    }
}