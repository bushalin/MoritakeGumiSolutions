using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.RepositoryModels
{
    public class LocationRM
    {
        public int LocationId { get; set; }
        public string CurrentLocation { get; set; }

        // ID for this application
        public string ApplicationUserId { get; set; }
    }
}