using NinjaCore2.Domain.Models;
using System.Collections.Generic;

namespace NinjaCore2.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserList();
        User GetUser(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
        void Save();
    }
}
