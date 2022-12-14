namespace Autopark.DAL.Interfaces
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task SaveAsync();
    }
}
