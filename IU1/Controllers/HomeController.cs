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
  public class HomeController : Controller
  {
    


    // GET: /<controller>/
    public IActionResult Index()
    {
      var userCase = HttpContext.Session.GetJson<Case>("NewCase");

      if (userCase == null)
      {
        return View();
      }
      else
      {
        return View(userCase);
      }
      
    }

    public IActionResult Login()
    {
      return View();
    }
  }
}
