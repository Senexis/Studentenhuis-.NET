using System;
using System.Collections.Generic;

namespace Avans.Studentenhuis.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity GetById(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        int Count(Func<TEntity, bool> predicate);
    }
}