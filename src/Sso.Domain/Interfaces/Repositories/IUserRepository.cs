using System.Threading.Tasks;
using Sso.Domain.Models;

namespace Sso.Domain.Interfaces.Repositories{
    public interface IUserRepository{
        Task<User> GetUserByUserName(string userName);
    }
}