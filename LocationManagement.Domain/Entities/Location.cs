using LocationManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public int LocationId { get; set; }
        public string CurrentLocation { get; set; }
        public string ApplicationUserId { get; set; }

        //public IApplicationUser ApplicationUser { get; set; }
        public BaseUser ApplicationUser { get; set; }
    }
}