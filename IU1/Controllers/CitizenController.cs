using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Infrastructure;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  public class CitizenController : Controller
  {

    private InterfaceRepository mymodel;


    public CitizenController(InterfaceRepository mymode)
    {

      mymodel = mymode;
    }

    // GET: /<controller>/
    public IActionResult Contact()
    {
      return View();
    }
    public IActionResult Faq()
    {
      return View();
    }
    public IActionResult Services()
    {
      return View();
    }
    public IActionResult Thanks()
    {
      var myCase = HttpContext.Session.GetJson<Case>("NewCase");
      mymodel.SaveCase(myCase);
      ViewBag.TId = myCase.RefNumber; //Makes the viewbag.TId be the relevant case
      HttpContext.Session.Remove("NewCase"); //removes the session
      return View();
    }

    //Validation och returnerar vy till "Citizen/Validate"
    [HttpPost]
    public IActionResult Validate(Case inCase)
    {

      HttpContext.Session.SetJson("NewCase", inCase);
      return View(inCase);
      
      
      
    }
  }
}
