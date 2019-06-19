using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IU1.Models
{

  //Interface som håller i funktionalitet för databas/POCO för hemsidan
  public interface InterfaceRepository
  {
    Task<Case> GetOneCase(String id);
    Case ReturnOneCase(String id);
    void SaveCase(Case inCase);
    String RelevantUser();
    IEnumerable<Case> GetRelevantCases();
    IEnumerable<Employee> GetRelevanEmployees();
    IEnumerable<Case> Cases { get; }
    IEnumerable<Department> Departments { get; }
    IEnumerable<Employee> Employees { get; }
    IEnumerable<Status> Statuses { get; }
    IEnumerable<Sample> Samples { get; }
    IEnumerable<Picture> Pictures { get; }
  }
}
