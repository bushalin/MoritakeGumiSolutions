using MG.Auth.Data.Common.Models;
using MG.Auth.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Data.User
{
    public class UserInfo : AuditableEntity<int>
    {
        // INITIALIZING REFER TO : https://www.youtube.com/watch?v=dK4Yb6-LxAk TIMESTAMP: 14:00 min
        public UserInfo()
        {
            Department = new Department();
            JobPosition = new JobPosition();
            ApplicationUser = new ApplicationUser();
        }

        public const string EmployeePrefix = "MG";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Concat(FirstName, " ", LastName);
            }
        }

        public string JobTitle { get; set; }
        public Gender Gender { get; set; }
        public BloodType BloodType { get; set; }
        public RestType RestType { get; set; }
        public string Address { get; set; }
        public string PostNo { get; set; }
        public DateTime DateOfBirth { get; set; }
#nullable enable
        public string? EmergencyContactNumber { get; set; }
#nullable disable

        // For Joining other tables
        public int DepartmentId { get; set; }

        public Department Department { get; private set; }

        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; private set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; private set; }
    }
}