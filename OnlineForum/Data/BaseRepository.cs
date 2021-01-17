using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineForum.Data
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected Context Context { get; private set; }

        public BaseRepository(Context context)
        {
            this.Context = context;
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

        public TEntity Get(int id)
        {
            return Context.Find<TEntity>(id);
        }

        public IList<TEntity> GetList()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
