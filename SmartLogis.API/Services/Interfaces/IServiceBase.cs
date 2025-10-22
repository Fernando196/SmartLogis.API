using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartLogis.API.Models;

namespace SmartLogis.API.Services.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(Dictionary<string, Filter>? body);
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}