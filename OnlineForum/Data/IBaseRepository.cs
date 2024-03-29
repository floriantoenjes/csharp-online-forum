﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace OnlineForum.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IList<TEntity> GetList(int offset = 0, int limit = 0);
        
        IList<TEntity> GetListByQuery(Expression<Func<TEntity,bool>> predicate, int offset = 0, int limit = 0);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        int Count();

        IDbContextTransaction StartTransaction();
    }
}
