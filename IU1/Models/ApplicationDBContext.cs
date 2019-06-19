using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IU1.Models
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    public DbSet<Case> Cases { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Sample> Samples { get; set; }
    public DbSet<Picture> Pictures { get; set; }
  }
}
