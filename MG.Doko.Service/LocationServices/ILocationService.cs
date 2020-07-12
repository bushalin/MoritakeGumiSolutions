using MG.Doko.Domain.DTOs.Location;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Service.LocationServices
{
    public interface ILocationService
    {
        EmployeeLocationDto GetLocationByEmployeeId(string employeeId);

        IEnumerable<LocationReadDto> GetAllLocations();

        LocationReadDto GetLocationById(int id);

        void LocationEdit(int id, LocationUpdateDto obj);

        void PartialLocationUpdate(int id, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);

        IEnumerable<EmployeeLocationDto> GetEmployeeLocations();

        LocationReadDto CreateLocation(LocationCreateDto model);

        void DeleteLocation(int id);

        void PartialLocationUpdateByEmployeeId(string employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);
    }
}