using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IU1.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
    public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }

    }
}
