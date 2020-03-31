using NinjaCore2.Data.Repositories.Abstract;
using NinjaCore2.Domain.Services.Abstract;

namespace NinjaCore2.Domain.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
