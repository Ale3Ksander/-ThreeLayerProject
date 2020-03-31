using System.Collections.Generic;
using NinjaCore2.Data.Entities;

namespace NinjaCore2.Data.Repositories.Abstract
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
