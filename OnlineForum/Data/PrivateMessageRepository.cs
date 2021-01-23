using System.Collections.Generic;
using System.Linq;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class PrivateMessageRepository : BaseRepository<Context, PrivateMessage>
    {
        public PrivateMessageRepository(Context context) : base(context)
        {
        }

        public override PrivateMessage Get(int id)
        {
            return Context.PrivateMessages.SingleOrDefault(pm => pm.Id == id);
        }

        public override IList<PrivateMessage> GetList()
        {
            return Context.PrivateMessages.ToList();
        }
    }
}