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

        private readonly IBaseRepository<User> _userRepository;

        public ThreadService(
            IBaseRepository<Board> boardRepository,
            IBaseRepository<Thread> threadRepository,
            IBaseRepository<User> userRepository
            )
        {
            _boardRepository = boardRepository;
            _threadRepository = threadRepository;
            _userRepository = userRepository;
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

        public void CreatePost(int threadId, Post post)
        {
            post.CreatorId = 1; // TODO: Replace with actual user
            post.CreatedAt = DateTime.Now;

            var user = _userRepository.Get(1);
            user.PostCount += 1;
            _userRepository.Update(user);

            var thread = GetThread(threadId);
            thread.Posts.Add(post);
            UpdateThread(thread);
        }
    }
}
