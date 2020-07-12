using AutoMapper;
using MG.Doko.Domain.Entities;
using MG.Doko.Repository.RepositoryModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Repository.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DokoApiDbContext _context;
        private readonly IMapper _mapper;

        public LocationRepository(DokoApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var result = _context.Locations.Find(id);
            _context.Remove(result);
        }

        public IEnumerable<Location> GetAll()
        {
            var result = _context.Locations.AsEnumerable();
            return result;
        }

        public IEnumerable<EmployeeLocationRM> GetEmployeeLocations()
        {
            var result = _context.Users.Select(x => new EmployeeLocationRM
            {
                ApplicationUserId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                JobTitle = x.JobTitle,
                CurrentLocation = _context.Locations.Where(v => v.ApplicationUser.Id == x.Id).Select(y => y.CurrentLocation).FirstOrDefault()
            }).ToList();

            return result;
        }

        public EmployeeLocationRM GetByEmployeeId(string employeeId)
        {
            //var result = _context.Locations.Where(x => x.EmployeeId == id).FirstOrDefault();
            var applicationUserId = _context.Users.Where(x => x.EmployeeId == employeeId).Select(x => x.Id).FirstOrDefault();
            var result = _context.Locations.Where(x => x.ApplicationUser.Id == applicationUserId)
                .Select(x => new EmployeeLocationRM
                {
                    ApplicationUserId = x.ApplicationUser.Id,
                    FirstName = x.ApplicationUser.FirstName,
                    LastName = x.ApplicationUser.LastName,
                    JobTitle = x.ApplicationUser.JobTitle,
                    CurrentLocation = x.CurrentLocation
                }).FirstOrDefault();
            return result;
        }

        public Location GetById(int id)
        {
            var result = _context.Locations.Find(id);
            return result;
        }

        public void Insert(Location model)
        {
            _context.Add(model);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Location model)
        {
            //DON'T HAVE TO DO ANYTHING, CAUSE AUTOMAPPER DOES THE TRACKING OF THE CONTEXT IN THE SERVICE LAYER
        }

        // This method is for PartialLocationUpdateByEmployeeId() in services
        public Location GetLocationByEmployeeId(string employeeId)
        {
            var result = _context.Locations.Where(x => x.ApplicationUserId == employeeId).Select(x => new Location
            {
                LocationId = x.LocationId,
                CurrentLocation = x.CurrentLocation,
                ApplicationUserId = x.ApplicationUser.Id
            }).FirstOrDefault();

            return result;
        }

        //public void UpdateEmployeeLocation(Guid employeeId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        //{
        //    var model = _context.Locations.Where(x => x.EmployeeId == employeeId).Select(x => new LocationModel
        //    {
        //        CurrentLocation = x.CurrentLocation,
        //        EmployeeId = x.EmployeeId,
        //        Id = x.Id
        //    }).FirstOrDefault();

        //    var locationModel = _mapper.Map<LocationUpdateDto>(model);

        //    jsonPatchDocument.ApplyTo(locationModel);

        //    var result = _mapper.Map(locationModel, model);

        //    _context.Entry(result).State = EntityState.Modified;

        //    _context.SaveChanges();
        //}

        public void UpdateLocationState(Location model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}