using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IU1.Models
{

  //Interface som håller i funktionalitet för databas/POCO för hemsidan
    public interface IFakeDataRepository
    {
      Task<Case> GetOneCase(String id);

    IEnumerable<Case> Cases { get; }
    IEnumerable<Department> Departments { get; }
    IEnumerable<Employee> Employees { get; }
    IEnumerable<Status> Statuses { get;  }
    }
}
