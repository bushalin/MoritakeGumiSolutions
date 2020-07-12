using MG.Auth.Data;
using MG.Auth.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Repository.UserRepositories
{
    public class UserRepository : IUserReposiotory
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserInfo GetAllUserInfoByUserId(int id)
        {
            var user = _context.Users.Find(id);
            var result = _context.UserInfo.Where(x => x.ApplicationUserId == id).FirstOrDefault();
        }
    }
}