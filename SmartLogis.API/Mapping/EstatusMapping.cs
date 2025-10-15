using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;

namespace SmartLogis.API.Mapping;
public static class EstatusMapping
{
    public static void RegisterMapping(TypeAdapterConfig config)
    {
        config.NewConfig<Estatus, EstatusDto>().TwoWays();
        config.NewConfig<Estatus, CreateEstatusDto>().TwoWays();
    }
}