using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class ThreadRepository : BaseRepository<Context, Thread>
    {
        public ThreadRepository(Context context) : base(context)
        {
        }

        public override Thread Get(int id)
        {
            return Context.Threads.Where(thread => thread.Id == id)
                .Include(thread => thread.Board)
                .Include(thread => thread.Creator)
                .Include(thread => thread.Subscribers).SingleOrDefault();
        }

        protected override IEnumerable<Thread> HandleIncludes(IQueryable<Thread> queryable)
        {
            return queryable.Include(thread => thread.Creator);
        }
    }
}