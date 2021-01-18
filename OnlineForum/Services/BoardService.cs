using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class BoardService
    {
        private readonly IBaseRepository<Board> _boardRepository;

        public BoardService(IBaseRepository<Board> boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public IList<Board> GetAllBoards()
        {
            return _boardRepository.GetList();
        }

        public void CreateBoard(Board board)
        {
            _boardRepository.Add(board);
        }

    }
}
