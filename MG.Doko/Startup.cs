using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MG.Doko.Middleware;
using MG.Doko.Repository.LocationRepositories;
using MG.Doko.Service.LocationServices;
using MG.Doko.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using MG.Doko.Domain.Entities;

namespace MG.Doko
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // adding dbcontext and sqlserver
            services.AddDbContext<DokoApiDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("DokoApiConnection"));
            });

            services.AddHttpClient();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigins",
                    builder =>
                    {
                        builder.AllowCredentials()
                        .AllowAnyHeader()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:4200");
                        //.AllowAnyOrigin();
                    });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // we need to add the nuget package (Microsoft.AspNetCore.Authentication.JwtBearer) and then add the jwtbearer service to the application
                // to make use of the jwtbearer authentication scheme
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    // the authority is where we are going to authenticate our application's user traffic
                    config.Authority = "https://localhost:44372/";

                    // we are introducting our api name to the identity server
                    // name of who we are
                    config.Audience = "dokoApi";
                });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DokoApiDbContext>();

            // using automapper for mapping the properties to the DTOs
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injecting IOC to the application
            services.BuildServiceContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowMyOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}