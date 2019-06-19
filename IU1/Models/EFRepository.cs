using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IU1.Models
{
  public class EFRepository : InterfaceRepository
  {
    //Variabler
    private ApplicationDBContext context;
    private IHttpContextAccessor ctxAccessor;
    //Konstruktor
    public EFRepository(ApplicationDBContext ctx, IHttpContextAccessor ctxa)
    {
      context = ctx;
      ctxAccessor = ctxa;
    }

    //Hämtar alla cases som är relevant för inloggad användare "manager" respektive "investigator"
    public IEnumerable<Case> GetRelevantCases()
    {
      var user = ctxAccessor.HttpContext.User.Identity.Name;
      var name = context.Employees.Where(e => e.EmployeeID == user).First().EmployeeName;
      var role = context.Employees.Where(e => e.EmployeeID == user).First().RoleTitle;
      var dep = context.Employees.Where(e => e.EmployeeID == user).First().Department;

      if (role.Equals("manager")) {
        return context.Cases.Where(d => d.Department == dep);
      } //if investigator
      return context.Cases.Where(e => e.Employee == name);


    }

    //Returns name of the logged in user
    public String RelevantUser()
    {
      var user = ctxAccessor.HttpContext.User.Identity.Name;
      return context.Employees.Where(e => e.EmployeeID == user).First().EmployeeName;
    }

    //Hämtar employees som är relevant för inloggad användare (chef)
    public IEnumerable<Employee> GetRelevanEmployees()
    {
      var user = ctxAccessor.HttpContext.User.Identity.Name;
      var dep = context.Employees.Where(e => e.EmployeeID == user).First().Department;
      return context.Employees.Where(d => d.Department == dep);
    }

    //Returnerar ett case
    public Case ReturnOneCase(String id)
    {

      Case oneCase = Cases.First(m => m.RefNumber.Equals(id));
      return oneCase;
    }

    //Returnerar ett case via task
    public Task<Case> GetOneCase(String id)
    {
      return Task.Run(() => {
        var oneCase = Cases.First(m => m.RefNumber.Equals(id));
        return oneCase;
      });
    }


    //Sparar ner ett helt nytt case, eller: om inCase inte är nytt så sparas ny information ner till existerande case
    public void SaveCase(Case inCase)
    {
      var refnumber = inCase.RefNumber;
      if (inCase.ID == 0) {
        context.Cases.Add(inCase);
      } else {
        Case dbEntry = context.Cases.FirstOrDefault(p => p.ID == inCase.ID);
        if (dbEntry != null) {
          dbEntry.InformerName = inCase.InformerName;
          dbEntry.Event = inCase.Event;
          dbEntry.DateOfObservation = inCase.DateOfObservation;
          dbEntry.Department = inCase.Department;
          dbEntry.Employee = inCase.Employee;
          dbEntry.Info = inCase.Info;
          dbEntry.InformerPhone = inCase.InformerPhone;
          dbEntry.Observation = inCase.Observation;
          dbEntry.Place = inCase.Place;
          dbEntry.RefNumber = inCase.RefNumber;
          dbEntry.Samples = inCase.Samples;
          dbEntry.Pictures = inCase.Pictures;

          context.SaveChanges();
          return;
        }
      }
      context.SaveChanges();
      inCase.RefNumber = refnumber + inCase.ID;
      context.SaveChanges();
    }

    public IEnumerable<Case> Cases => context.Cases.Include(c => c.Samples).Include(c => c.Pictures);
    public IEnumerable<Department> Departments => context.Departments;
    public IEnumerable<Employee> Employees => context.Employees;
    public IEnumerable<Status> Statuses => context.Statuses;
    public IEnumerable<Sample> Samples => context.Samples;
    public IEnumerable<Picture> Pictures => context.Pictures;
  }
}
