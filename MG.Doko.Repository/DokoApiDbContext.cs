using MG.Doko.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MG.Doko.Repository.LocationRepositories
{
    public class DokoApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public DokoApiDbContext(DbContextOptions<DokoApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Employee>()
            //    .HasOne<Location>(e => e.Location)
            //    .WithOne(l => l.Employee)
            //    .HasForeignKey<Location>(l => l.EmployeeId);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(a => a.Location)
            //    .WithOne(l => l.ApplicationUser)
            //    .HasForeignKey<Location>(l => l.ApplicationUserId);

            // Location table has one application user and applicationUser has one location. use location table's applicationUserId as foreign key
            modelBuilder.Entity<Location>()
                .HasOne(a => a.ApplicationUser)
                .WithOne(l => l.Location)
                .HasForeignKey<Location>(a => a.ApplicationUserId);

            //modelBuilder.Entity<Location>().ToTable("Locations");
        }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}