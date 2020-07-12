using MG.Doko.Domain.DTOs;
using MG.Doko.Domain.DTOs.Users;
using MG.Doko.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Service.UserServices
{
    public interface IUserServices
    {
        ApplicationUser GetUserByEmployeeId(string userId);

        IdentityResult CreateUser(UserCreateDto user);

        void UpdateUserInfo(string userId, UpdateUserInfoDto userInfoDto);
    }
}