using Mapster;
using SmartLogis.API.Models;
using SmartLogis.API.Models.Dtos;

namespace SmartLogis.API.Mapping
{
    public class RutasMapping
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<Rutas,RutasDto>().TwoWays();
            config.NewConfig<Rutas,CreateRutasDto>().TwoWays();
        }
    }
}