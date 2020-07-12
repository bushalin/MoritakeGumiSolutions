using MG.Auth.Data.User;

namespace MG.Auth.Repository.UserRepositories
{
    public interface IUserReposiotory
    {
        UserInfo GetAllUserInfoByUserId(int id);
    }
}