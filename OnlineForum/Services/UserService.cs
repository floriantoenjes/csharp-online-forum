using System.Collections;
using System.Collections.Generic;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class UserService
    {
        private readonly IBaseRepository<User> _userRepository;
        
        
        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetList();
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(userId);
        }
    }
}