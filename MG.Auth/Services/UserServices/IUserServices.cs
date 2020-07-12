using MG.Auth.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Services.UserServices
{
    public interface IUserServices
    {
        UserInfo GetAllUserInfo();
    }
}