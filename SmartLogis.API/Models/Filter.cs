using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Filter
    {
        public object Eq { get; set; } = new();
        public object Ne { get; set; } = new();
        public object Gt { get; set; } = new();
        public object Lt { get; set; } = new();
        public object Gte { get; set; } = new();
        public object Lte { get; set; } = new();
        public object Contains { get; set; } = new();
        public object In { get; set; } = new();
    }
}