using MG.Auth.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Data.Common.Models
{
    public class JobPosition : AuditableEntity<int>
    {
        public string Name { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}