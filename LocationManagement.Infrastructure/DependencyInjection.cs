using LocationManagement.Application.Common.Interfaces;
using LocationManagement.Infrastructure.Data;
using LocationManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("DokoApiConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // we need to add the nuget package (Microsoft.AspNetCore.Authentication.JwtBearer) and then add the jwtbearer service to the application
            // to make use of the jwtbearer authentication scheme
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
            {
                // the authority is where we are going to authenticate our application's user traffic
                config.Authority = "https://localhost:44372/";

                // we are introducting our api name to the identity server
                // name of who we are
                config.Audience = "locationManagerApi";
            });

            return services;
        }
    }
}