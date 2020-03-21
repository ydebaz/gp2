using gp_.Models;
using System.Threading.Tasks;

namespace gp_.Services
{
    public interface IUserService
    {
        Task<bool> Isonline(string name);
        Task<bool> RegisterUser(UserModel userModel);

        Task<UserModel> GetUserByEmail(string email);

        Task UpdateUser(UserModel user);
    }
}