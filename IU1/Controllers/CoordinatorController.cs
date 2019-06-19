using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IU1.Components;
using IU1.Infrastructure;
using IU1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  [Authorize(Roles = "Coordinator")]
  public class CoordinatorController : Controller
  {

    // GET: /<controller>/
    private InterfaceRepository mymodel;
    
    //konstruktor
    public CoordinatorController(InterfaceRepository mymode)
    {
      
      mymodel = mymode;
    }

    //Updates only department
    [HttpPost]
    public IActionResult UpdateDepartment(Department department, String id)
    {
      if (!department.DepartmentName.Equals("Välj")) //something must be chosen
      {
        Case tempCase = mymodel.ReturnOneCase(id);
        tempCase.Department = department.DepartmentName;
        mymodel.SaveCase(tempCase);
      } 
      
      return RedirectToAction("StartCoordinator"); //redirect to StartCoordinator
    }
    public IActionResult CrimeCoordinator(String id)
    {
      ViewBag.User = mymodel.RelevantUser();
      ViewBag.ListOfDepartments = mymodel.Departments;
      ViewBag.TId = id;
      return View();
    }
    public IActionResult ReportCrime()
    {
      var userCase = HttpContext.Session.GetJson<Case>("NewCase");

      if (userCase == null) {
        return View();
      } else {
        return View(userCase);
      }
    }
    public IActionResult StartCoordinator()
    {
      ViewBag.User = mymodel.RelevantUser();
      return View(mymodel);
    }
    public IActionResult Thanks()
    {
      var myCase = HttpContext.Session.GetJson<Case>("NewCase");
      mymodel.SaveCase(myCase);
      

      HttpContext.Session.Remove("NewCase");
      return View();
    }

    //Validation och returnerar vy till "Coordinator/Validate"
    public IActionResult Validate(Case inCase)
    {
      HttpContext.Session.SetJson("NewCase", inCase);
      return View(inCase);
    }
  }
}
