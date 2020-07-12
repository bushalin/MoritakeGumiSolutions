using AutoMapper;
using MG.Auth.Data;
using MG.Auth.Data.User;
using MG.Auth.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Auth.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // source -> destination
            CreateMap<RegisterViewModel, UserInfo>();
            CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}