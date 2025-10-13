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
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> FindAsync(FiltrosDto filtrosDto);
    }
}