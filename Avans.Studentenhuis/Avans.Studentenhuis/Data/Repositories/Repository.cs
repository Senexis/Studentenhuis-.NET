using System;
using System.Collections.Generic;
using System.Linq;
using Avans.Studentenhuis.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avans.Studentenhuis.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected void Save() => _context.SaveChanges();

        public void Create(TEntity entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            Save();
        }

        public int Count(Func<TEntity, bool> predicate) => _context.Set<TEntity>().Where(predicate).Count();

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) => _context.Set<TEntity>().Where(predicate);

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity GetById(Guid id) => _context.Set<TEntity>().Find(id);
    }
}
