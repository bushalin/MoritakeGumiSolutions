using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.RepositoryModels
{
    public class UserInfoRM
    {
        public string Username { get; set; }
        public string EmpmloyeeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermanentAddress { get; set; }
        public string Jobtitle { get; set; }
    }
}