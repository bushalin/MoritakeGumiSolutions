using MG.Auth.Data.Enums;
using MG.Auth.Data.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public const string EmployeePrefix = "MG";
        public bool IsITAdmin { get; set; }

        public string EmployeeId
        {
            get
            {
                return string.Concat(EmployeePrefix, base.Id);
            }
        }

        public int UserInfoId { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}