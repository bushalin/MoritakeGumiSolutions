using MG.Auth.Data.User;
using MG.Auth.Repository.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserReposiotory _userRepository;

        public UserServices(IUserReposiotory userReposiotory)
        {
            _userRepository = userReposiotory;
        }

        public UserInfo GetAllUserInfo()
        {
            throw new NotImplementedException();
        }
    }
}