﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class BoardRepository : BaseRepository<Context, Board>
    {
        public BoardRepository(Context context) : base(context)
        {
        }

        public override Board Get(int id)
        {
            return Context.Boards.Where(board => board.Id == id)
                .Include(board => board.Threads).ThenInclude(thread => thread.Creator).SingleOrDefault();
        }

        public override IList<Board> GetList()
        {
            return Context.Boards.ToList();
        }
    }
}