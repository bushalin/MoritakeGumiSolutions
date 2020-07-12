using MG.Doko.Domain.DTOs.Users;
using MG.Doko.Domain.Entities;
using MG.Doko.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.UserRepositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByEmployeeId(string userId);
    }
}