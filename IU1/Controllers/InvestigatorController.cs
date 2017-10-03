using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
    public class InvestigatorController : Controller
    {
      private IFakeDataRepository mymodel;

      public InvestigatorController(IFakeDataRepository mymode)
      {
        mymodel = mymode;
      }
        // GET: /<controller>/
        public IActionResult CrimeInvestigator(String id)
        {
          ViewBag.TId = id;
      return View(mymodel);
        }
      public IActionResult StartInvestigator()
      {
        return View(mymodel);
      }
  }
}
