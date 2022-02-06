using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
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

        public IList<Thread> GetThreadsByBoardId(int boardId, int offset = 0, int limit = 5)
        {
            Console.WriteLine(boardId);
            return _threadRepository.GetListByQuery(thread => thread.BoardId == boardId, offset, limit);
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

        public void CreatePost(int threadId, Post post, int userId, bool withTransaction = true)
        {
            IDbContextTransaction transaction = null;
            if (withTransaction)
            {
                transaction = _threadRepository.StartTransaction();
            }

            post.CreatorId = userId;

            var user = _userRepository.Get(userId);
            user.PostCount += 1;
            _userRepository.Update(user);

            var thread = GetThread(threadId);
            thread.Posts.Add(post);
            UpdateThread(thread);

            if (withTransaction)
            {
                transaction?.Commit();
            }
        }

        public void SubscribeToThread(int threadId, int currentUserId)
        {
            var user = _userRepository.Get(currentUserId);
            
            var thread = GetThread(threadId);
            thread.Subscribers.Add(user);
            
            _threadRepository.Update(thread);
        }

        public void UnsubscribeFromThread(int threadId, int currentUserId)
        {
            var user = _userRepository.Get(currentUserId);

            var thread = GetThread(threadId);
            thread.Subscribers.Remove(user);
            
            _threadRepository.Update(thread);
        }
    }
}
