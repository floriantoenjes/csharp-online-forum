using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class UserRepository : BaseRepository<Context, User>
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public override User Get(int id)
        {
            return Context.Users
                .Include(u => u.Subscriptions)
                .SingleOrDefault(user => user.Id == id);
        }

        public override IList<User> GetList()
        {
            return Context.Users.ToList();
        }
    }
}