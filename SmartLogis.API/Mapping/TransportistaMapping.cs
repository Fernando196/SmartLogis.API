using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;

namespace SmartLogis.API.Mapping
{
    public class TransportistaMapping
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<Transportista,TransportistaDto>().TwoWays();
            config.NewConfig<Transportista,CreateTransportistaDto>().TwoWays();
            config.NewConfig<Transportista,UpdateTransportistaDto>().TwoWays();
        }
    }
}