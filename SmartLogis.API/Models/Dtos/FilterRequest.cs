using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class FilterRequest
    {
        public Dictionary<string, Filter> Filters { get; set; } = new();
    }
}