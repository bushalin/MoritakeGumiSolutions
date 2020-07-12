using MG.Doko.Domain.DTOs.Location;
using MG.Doko.Service.LocationServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MG.Doko.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _services;

        public LocationController(ILocationService locationService)
        {
            _services = locationService;
        }

        #region BASIC_CRUD

        // GET /api/Location
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var result = _services.GetAllLocations();
            return Ok(result);
        }

        // GET /api/location/{id}
        [HttpGet("{id}", Name = "GetLocationById")]
        public IActionResult GetLocationById(int id)
        {
            var result = _services.GetLocationById(id);
            return Ok(result);
        }

        // POST /api/location
        [HttpPost]
        public IActionResult CreateLocation([FromBody]LocationCreateDto model)
        {
            var result = _services.CreateLocation(model);
            return CreatedAtRoute(nameof(GetLocationById), new { Id = result.LocationId }, result);
        }

        // PUT /api/location
        [HttpPut("{id}")]
        public IActionResult EditLocation(int id, LocationUpdateDto model)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }
            _services.LocationEdit(id, model);
            return NoContent();
        }

        // PATCH /api/location/{id}
        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }
            _services.PartialLocationUpdate(id, jsonPatchDocument);

            return NoContent();
        }

        // DELETE /api/location/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            var result = _services.GetLocationById(id);
            if (result == null)
            {
                return NotFound();
            }

            _services.DeleteLocation(id);

            return NoContent();
        }

        #endregion BASIC_CRUD

        #region EMPLOYEE_SPECIFIC_LOCATION

        // GET /api/location/GetByEmployeeId/{id}
        [HttpGet]
        [Route("GetLocationByEmployeeId/{id}")]
        public IActionResult GetLocationByEmployeeId(string id)
        {
            var result = _services.GetLocationByEmployeeId(id);

            return Ok(result);
        }

        // GET /api/location/GetAllEmployeeLocations
        [HttpGet]
        [Route("GetAllEmployeeLocations")]
        public IActionResult GetAllEmployeeLocations()
        {
            var result = _services.GetEmployeeLocations();

            return Ok(result);
        }

        // PATCH /api/location/UpdateEmployeeLocation/{id}
        [HttpPatch]
        [Route("UpdateEmployeeLocation/{applicationUserId}")]
        public IActionResult UpdateEmployeeLocation(string applicationUserId, JsonPatchDocument<LocationUpdateDto> jsonPatchDocument)
        {
            //var result = _services.GetLocationByEmployeeId(employeeId);
            //if (result == null)
            //{
            //    return NotFound();
            //}

            _services.PartialLocationUpdateByEmployeeId(applicationUserId, jsonPatchDocument);
            return NoContent();
        }

        #endregion EMPLOYEE_SPECIFIC_LOCATION
    }
}