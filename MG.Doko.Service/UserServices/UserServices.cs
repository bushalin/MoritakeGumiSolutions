using MG.Doko.Domain.DTOs;
using MG.Doko.Domain.DTOs.Users;
using MG.Doko.Domain.Entities;
using MG.Doko.Repository.UserRepositories;
using Microsoft.AspNetCore.Identity;

namespace MG.Doko.Service.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public ApplicationUser GetUserByEmployeeId(string userId)
        {
            var result = _userRepository.GetUserByEmployeeId(userId);
            return result;
        }

        public IdentityResult CreateUser(UserCreateDto user)
        {
            var userModel = new ApplicationUser
            {
                EmployeeId = user.EmployeeId,
                UserName = user.Username
            };
            var result = _userManager.CreateAsync(userModel).GetAwaiter().GetResult();
            return result;
        }

        public void UpdateUserInfo(string userId, UpdateUserInfoDto userInfoDto)
        {
            var result = _userManager;
        }
    }
}