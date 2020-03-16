using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gp_.Models;
using gp_.Services;

namespace gp_.Services
{
    public class UserService : IUserService
    {
        public Task<bool> RegisterUser(UserModel userModel) { return Task.FromResult(true); }
        public Task<bool> Isonline(string name) { return Task.FromResult(true); }
    }
}
