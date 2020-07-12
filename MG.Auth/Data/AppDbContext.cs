using MG.Auth.Data.Common.Models;
using MG.Auth.Data.User;
using MG.Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MG.Auth.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 1-1 relationship with ApplicationUser and UserInfo
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.UserInfo)
                .WithOne(a => a.ApplicationUser)
                .HasForeignKey<ApplicationUser>(u => u.UserInfoId);

            // configuring ApplicationUser
            builder.Entity<ApplicationUser>()
                .Ignore(a => a.EmployeeId);

            // configuring UserInfo
            builder.Entity<UserInfo>()
                .Ignore(u => u.FullName);

            // 1-1 relationship with UserInfo and Department
            builder.Entity<UserInfo>()
                .HasOne(d => d.Department)
                .WithOne(u => u.UserInfo)
                .HasForeignKey<UserInfo>(d => d.DepartmentId);

            // 1-1 relationship with UserInfo and JobPosition
            builder.Entity<UserInfo>()
                .HasOne(j => j.JobPosition)
                .WithOne(u => u.UserInfo)
                .HasForeignKey<UserInfo>(j => j.JobPositionId);
        }

        public DbSet<MG.Auth.Data.User.UserInfo> UserInfo { get; set; }
    }
}