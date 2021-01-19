using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineForum.Data
{
    public abstract class BaseRepository<TDbContext, TEntity> : IBaseRepository<TEntity> where TDbContext : DbContext where TEntity : class
    {
        protected TDbContext Context { get; set; }

        protected BaseRepository(TDbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Context.Find<TEntity>(id);
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public abstract TEntity Get(int id);

        public abstract IList<TEntity> GetList();

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public int Count()
        {
            return Context.Set<TEntity>().ToList().Count;
        }
    }
}
