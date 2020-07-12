using MG.Doko.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Domain.Entities
{
    public class Location : AuditableEntitiy
    {
        public int LocationId { get; set; }
        public string CurrentLocation { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}