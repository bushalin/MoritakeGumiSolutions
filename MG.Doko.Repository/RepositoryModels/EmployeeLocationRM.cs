using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.RepositoryModels
{
    public class EmployeeLocationRM
    {
        // ID for this application
        public string ApplicationUserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string CurrentLocation { get; set; }
    }
}