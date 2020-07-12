using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MG.Doko.UI
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
            // creates the client of doko api
            services.AddHttpClient("api", options =>
            {
                options.BaseAddress = new Uri("https://localhost:44361/api/");
            });

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = "Cookie";
                config.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookie")
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = "https://localhost:44372/";
                    config.ClientId = "doko.ui";
                    config.ClientSecret = "doko_ui_secret";

                    config.SaveTokens = true;
                    config.ResponseType = "code";

                    // configure cookie claim mapping
                    // two trips to make the id token smaller
                    config.GetClaimsFromUserInfoEndpoint = true;
                    config.ClaimActions.DeleteClaim("amr");
                    config.ClaimActions.DeleteClaim("s_hash");
                    config.ClaimActions.MapUniqueJsonKey("TestClaim", "test_claim");
                    config.ClaimActions.MapUniqueJsonKey("profile", "profile");
                    config.ClaimActions.MapUniqueJsonKey("firstName", "firstName");
                    config.ClaimActions.MapUniqueJsonKey("lastName", "lastName");
                    config.ClaimActions.MapUniqueJsonKey("address", "address");
                    config.ClaimActions.MapUniqueJsonKey("gender", "gender");
                    config.ClaimActions.MapUniqueJsonKey("role", "role");

                    config.Scope.Clear();
                    config.Scope.Add("dokoApi");
                    config.Scope.Add("mg.scope");
                    //config.Scope.Add("profile");
                    config.Scope.Add(OidcConstants.StandardScopes.OpenId);
                    config.Scope.Add(OidcConstants.StandardScopes.Profile);
                    config.Scope.Add(OidcConstants.StandardScopes.Address);
                    config.Scope.Add(OidcConstants.StandardScopes.Email);
                    config.Scope.Add(OidcConstants.StandardScopes.Phone);
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}