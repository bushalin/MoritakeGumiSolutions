using AutoMapper;
using MG.Doko.Domain.DTOs.Location;
using MG.Doko.Domain.Entities;
using MG.Doko.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.Profiles
{
    public class LocationProfile : Profile
    {
        // souce -> desitnation
        public LocationProfile()
        {
            CreateMap<Location, LocationReadDto>();
            CreateMap<EmployeeLocationRM, EmployeeLocationDto>();
            CreateMap<LocationCreateDto, Location>();
            CreateMap<LocationUpdateDto, Location>();
            CreateMap<Location, LocationUpdateDto>();
            CreateMap<LocationRM, LocationUpdateDto>();
            CreateMap<LocationUpdateDto, LocationRM>();
        }
    }
}