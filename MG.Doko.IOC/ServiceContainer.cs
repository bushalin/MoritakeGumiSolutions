using MG.Doko.Repository.LocationRepositories;
using MG.Doko.Repository.UserRepositories;
using MG.Doko.Service.LocationServices;
using MG.Doko.Service.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.IOC
{
    public static class ServiceContainer
    {
        public static void BuildServiceContainer(this IServiceCollection services)
        {
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IUserServices, UserServices>();

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}