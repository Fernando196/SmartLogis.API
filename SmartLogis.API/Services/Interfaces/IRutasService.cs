using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Services.Interfaces
{
    public interface IRutasService: IServiceBase<Rutas>
    {
        Task<string> GenerarCodigoRutaAsync();
    }
}