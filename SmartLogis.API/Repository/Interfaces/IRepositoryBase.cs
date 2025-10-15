using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartLogis.API.Repository.Interfaces;
public interface IRepositoryBase<T>
{
    IQueryable<T> GetAllQueryable();
    Task<T?> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> SaveAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
}