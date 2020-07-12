using AutoMapper;
using MG.Doko.Domain.Entities;
using MG.Doko.Repository.LocationRepositories;
using MG.Doko.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DokoApiDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DokoApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ApplicationUser GetUserByEmployeeId(string userId)
        {
            var result = _context.Users.Where(x => x.EmployeeId == userId).FirstOrDefault();

            return result;
        }
    }
}