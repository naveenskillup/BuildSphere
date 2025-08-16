using System;

using BuildSphere.Common.Definitions;

namespace BuildSphere.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetByUserName(string userName);
        Task<User> GetByUserNameAndPassword(string userName, string password);
        Task Create(User user);
        Task Update(int id, User user);
        Task Delete(int id);
    }
}
