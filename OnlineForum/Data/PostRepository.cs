using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class PostRepository : BaseRepository<Context, Post>
    {
        public PostRepository(Context context) : base(context)
        {
        }

        public override Post Get(int id)
        {
            return Context.Posts.SingleOrDefault(post => post.Id == id);
        }

        protected override IEnumerable<Post> HandleIncludes(IQueryable<Post> queryable)
        {
            return queryable.Include(post => post.Creator);
        }
    }
}