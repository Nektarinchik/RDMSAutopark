namespace Autopark.DAL.Interfaces
{
    public interface IRepository<TEntity> :IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task SaveAsync();
    }
}
