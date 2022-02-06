using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineForum.Models;

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

        public virtual IList<TEntity> GetList(int offset = 0, int limit = 0)
        {
            IQueryable<TEntity> dbSet = Context.Set<TEntity>();

            dbSet = BuildPaginatedQuery(dbSet, offset, limit);

            return HandleIncludes(dbSet).ToList();
        }

        private IQueryable<TEntity> BuildPaginatedQuery(IQueryable<TEntity> queryable, int offset, int limit)
        {
            if (offset != 0 || limit != 0)
            {
                if (offset != 0)
                {
                    queryable = queryable.Skip(offset);
                }

                if (limit != 0)
                {
                    queryable = queryable.Take(limit);
                }
            }

            return queryable;
        }

        protected virtual IEnumerable<TEntity> HandleIncludes(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        public IList<TEntity> GetListByQuery( Expression<Func<TEntity,bool>> predicate, int offset = 0, int limit = 0)
        {
            var set = Context.Set<TEntity>();
            return HandleIncludes(BuildPaginatedQuery(set.Where(predicate), offset, limit)).ToList();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public int Count()
        {
            return Context.Set<TEntity>().ToList().Count;
        }

        public IDbContextTransaction StartTransaction()
        {
            return Context.Database.BeginTransaction();
        }
        
    }
}
