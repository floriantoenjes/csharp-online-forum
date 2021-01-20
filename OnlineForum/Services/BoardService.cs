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

        public Board GetBoard(int boardId)
        {
            return _boardRepository.Get(boardId);
        }

        public void UpdateBoard(Board board)
        {
            _boardRepository.Update(board);
        }

        public int GetThreadCount()
        {
            return _boardRepository.Count();
        }

        public void CreateThread(int boardId, Thread thread)
        {
            thread.CreatorId = 1; // TODO: Replace with actual user
            thread.CreatedAt = DateTime.Now;
            
            var board = GetBoard(boardId);
            board.Threads.Add(thread);
            board.LastThread = thread;
            board.ThreadCount = GetThreadCount();
            UpdateBoard(board);
        }
    }
}
