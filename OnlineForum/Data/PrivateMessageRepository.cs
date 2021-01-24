﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class PrivateMessageRepository : BaseRepository<Context, PrivateMessage>, IPrivateMessageRepository
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

        public IList<PrivateMessage> GetPrivateMessagesByUserId(int userId)
        {
            return Context.PrivateMessages
                .Include(pm => pm.Sender)
                .Include(pm => pm.Recipient)
                .Where(pm => pm.SenderId == userId || pm.RecipientId == userId).ToList();
        }
    }
}