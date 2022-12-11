namespace Autopark.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        TEntity Update(TEntity entity);
        Task Delete(int id);
        Task Save();
    }
}
