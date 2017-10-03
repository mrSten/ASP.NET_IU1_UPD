using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IU1.Components;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  public class CoordinatorController : Controller
  {

    // GET: /<controller>/
    private IFakeDataRepository mymodel;
    

    public CoordinatorController(IFakeDataRepository mymode)
    {
      
      mymodel = mymode;
    }

    
    public IActionResult CrimeCoordinator(String id)
    {
      ViewBag.TId = id;
      return View(mymodel);
    }
    public IActionResult ReportCrime()
    {
      return View();
    }
    public IActionResult StartCoordinator()
    {
      return View(mymodel);
    }
    public IActionResult Thanks()
    {
      return View();
    }

    //Validation och returnerar vy till "Coordinator/Validate"
    public IActionResult Validate(Case inCase)
    {
      if (ModelState.IsValid) {
        return View("Validate", inCase);
      } else {
        return View();
      }
    }
  }
}
