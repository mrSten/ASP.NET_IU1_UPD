using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IU1.Models
{
  public class EFRepository : IFakeDataRepository
  {
    private ApplicationDBContext context;

    public EFRepository(ApplicationDBContext ctx)
    {
      context = ctx;
    }
    public Task<Case> GetOneCase(String id)
    {
      return Task.Run(() => {
        var oneCase = Cases.First(m => m.RefNumber.Equals(id));
        return oneCase;
      });
    }
    public IEnumerable<Case> Cases => context.Cases;
    public IEnumerable<Department> Departments => context.Departments;
    public IEnumerable<Employee> Employees => context.Employees;
    public IEnumerable<Status> Statuses => context.Statuses;
  }
}
