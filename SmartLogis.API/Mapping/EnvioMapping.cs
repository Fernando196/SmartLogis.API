using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;

namespace SmartLogis.API.Mapping
{
    public class EnvioMapping
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<Envio, EnvioDto>().TwoWays();
            config.NewConfig<Envio, CreateEnvioDto>().TwoWays();
            config.NewConfig<Envio, UpdateEnvioDto>().TwoWays();
        }
    }
}