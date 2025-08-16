using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSphere.Common.Definitions;
using BuildSphere.Common.Exceptions;
using BuildSphere.Core.Interfaces;
using BuildSphere.Data.Repository.Interfaces;

namespace BuildSphere.Core.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userService)
            => _userRepository = userService;

        public async Task<IEnumerable<User>> Get()
            => await _userRepository.Get();

        public async Task<User> GetByUserName(string userName)
        => await _userRepository.GetByUserName(userName);
        
        public async Task<User> GetByUserNameAndPassword(string userName, string password)
         => await _userRepository.GetByUserNameAndPassword(userName, password);

        public async Task Create(User user)
         => await _userRepository.Create(user);


        public async Task Update(int id, User user)
         => await _userRepository.Update(id, user);

        public async Task Delete(int id)
         => await _userRepository.Delete(id);

        private readonly IUserRepository _userRepository;
    }
}
