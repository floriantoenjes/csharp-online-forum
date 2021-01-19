using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IList<TEntity> GetList();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        int Count();
    }
}
