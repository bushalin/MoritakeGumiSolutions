using LocationManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocationManagement.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Location> Locations { get; set; }

        // For Audit
        // We need service for the current login user, so we will create an interface in the folder
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}