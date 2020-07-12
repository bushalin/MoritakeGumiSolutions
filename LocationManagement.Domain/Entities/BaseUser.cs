using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Domain.Entities
{
    public class BaseUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Concat(FirstName + " " + LastName);
            }
        }

        public string JobTitle { get; set; }
        public string PermanentAddress { get; set; }
        public string EmployeeId { get; set; }

        public Location Location { get; set; }
    }
}