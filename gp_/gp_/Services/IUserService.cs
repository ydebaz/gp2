using gp_.Models;
using System.Threading.Tasks;

namespace gp_.Services
{
    public interface IUserService
    {
        Task<bool> Isonline(string name);
        Task<bool> RegisterUser(UserModel userModel);
    }
}