using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sso.Domain.Interfaces.Repositories;
using Sso.Domain.Models;

namespace Sso.Infra{
    public class UserRepository : IUserRepository
    {
        private readonly IEnumerable<User> _usersMock = new List<User>{
            new User{
                Id = "123",
                UserName = "douglaslessa",
                Password = "123xpto456"
            }
        };
        public async Task<User> GetUserByUserName(string userName)
        {
            return _usersMock.First(u => u.UserName.Equals(userName));
        }
    }
}