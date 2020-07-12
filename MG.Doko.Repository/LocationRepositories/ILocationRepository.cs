using MG.Doko.Domain.Entities;
using MG.Doko.Repository.RepositoryModels;
using System;
using System.Collections.Generic;

namespace MG.Doko.Repository.LocationRepositories
{
    public interface ILocationRepository
    {
        Location GetById(int id);

        IEnumerable<Location> GetAll();

        void Insert(Location model);

        void Update(Location model);

        void Delete(int id);

        void SaveChanges();

        EmployeeLocationRM GetByEmployeeId(string id);

        IEnumerable<EmployeeLocationRM> GetEmployeeLocations();

        // This method is for PartialLocationUpdateByEmployeeId() in services
        Location GetLocationByEmployeeId(string employeeId);

        //void UpdateEmployeeLocation(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument);

        void UpdateLocationState(Location model);
    }
}