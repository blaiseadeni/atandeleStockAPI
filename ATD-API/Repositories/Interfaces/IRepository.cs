using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATD_API.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}