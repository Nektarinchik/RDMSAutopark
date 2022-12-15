using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.DAL.Interfaces
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
    }
}
