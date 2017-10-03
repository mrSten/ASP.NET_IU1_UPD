using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
    public class ManagerController : Controller
    {
      private IFakeDataRepository mymodel;

      public ManagerController(IFakeDataRepository mymode)
      {
        mymodel = mymode;
      }
        // GET: /<controller>/
        public IActionResult CrimeManager(String id)
        {
          ViewBag.TId = id;
      return View(mymodel);
        }
      public IActionResult StartManager()
      {
        return View(mymodel);
      }
  }
}
