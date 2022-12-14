﻿namespace Autopark.DAL.Interfaces
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        Task Save();
    }
}