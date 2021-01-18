using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class ThreadService
    {
        private readonly IBaseRepository<Board> _boardRepository;

        private readonly IBaseRepository<Thread> _threadRepository;

        public ThreadService(IBaseRepository<Board> boardRepository, IBaseRepository<Thread> threadRepository)
        {
            _boardRepository = boardRepository;
            _threadRepository = threadRepository;
        }

        public Thread GetThread(int threadId)
        {
            return _threadRepository.Get(threadId);
        }

        public void CreateThread(int boardId, Thread thread)
        {
            var board = _boardRepository.Get(boardId);
            board.Threads.Add(thread);
            _boardRepository.Update(board);
        }

        public void UpdateThread(Thread thread)
        {
            _threadRepository.Update(thread);
        }

    }
}
