using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Interfaces
{
    public interface IRepositoryCompositeKey<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int firstId, int secondId);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int firstId, int secondId);
        Task SaveAsync();
    }
}
