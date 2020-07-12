using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Domain.DTOs.Location
{
    public class EmployeeLocationUpdateDto
    {
        public string LocationId { get; set; }
        public string CurrentLocation { get; set; }
        public Guid EmployeeId { get; set; }
    }
}