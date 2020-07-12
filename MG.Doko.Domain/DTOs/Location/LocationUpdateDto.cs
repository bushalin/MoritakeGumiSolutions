using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Domain.DTOs.Location
{
    public class LocationUpdateDto
    {
        public string CurrentLocation { get; set; }
        public string ApplicationUserId { get; set; }
    }
}