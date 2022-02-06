using System.Collections.Generic;
using System.Linq;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class PostService
    {
        private readonly IBaseRepository<Post> _postRepository;

        public PostService(IBaseRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IList<Post> GetPostsByThreadId(int threadId, int offset = 0, int limit = 0)
        {
            return _postRepository.GetListByQuery(post => post.ThreadId == threadId, offset, limit);
        }

        public int GetPostsBbyThreadIdTotalCount(int threadId)
        {
            return _postRepository.GetListByQuery(post => post.ThreadId == threadId).Count();
        }
    }
}