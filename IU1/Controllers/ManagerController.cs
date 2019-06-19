using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  [Authorize(Roles="Manager")]
  public class ManagerController : Controller
  {
    private InterfaceRepository mymodel;

    //konstruktor
    public ManagerController(InterfaceRepository mymode)
    {
      mymodel = mymode;
    }

    // GET: /<controller>/

    //uppdaterar employee enligt inparameter
    [HttpPost]
    public IActionResult UpdateEmployee(Employee employee, String id)
    {
      if (!employee.EmployeeName.Equals("Välj")) { //något måste vara valt
        Case tempCase = mymodel.ReturnOneCase(id);
        tempCase.Employee = employee.EmployeeName;
        mymodel.SaveCase(tempCase);
      }

      return RedirectToAction("StartManager"); //redirect till StartManager
    }

    //Uppdaterar info enligt inparameter
    [HttpPost]
    public IActionResult UpdateInfo(String id, bool noAction, string info)
    {
      if (noAction) { //action måste vara i-clickad (tolkade jag det som i uppgiften?) annars uppdateras inte info
        Case tempCase = mymodel.ReturnOneCase(id);
        tempCase.Status = "Ingen åtgärd";
        tempCase.Info += "\n" + info;
        mymodel.SaveCase(tempCase);
      }

      return RedirectToAction("StartManager"); //redirect till StartManager
    }

    public IActionResult CrimeManager(String id)
    {
      ViewBag.User = mymodel.RelevantUser();
      ViewBag.ListOfEmployees = mymodel.GetRelevanEmployees();
      ViewBag.TId = id;
      return View();
    }
    public IActionResult StartManager()
    {
      ViewBag.User = mymodel.RelevantUser();
      return View(mymodel);
    }
  }
}
