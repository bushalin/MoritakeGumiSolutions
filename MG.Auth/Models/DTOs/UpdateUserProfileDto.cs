using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Models.DTOs
{
    public class UpdateUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermanentAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
    }
}