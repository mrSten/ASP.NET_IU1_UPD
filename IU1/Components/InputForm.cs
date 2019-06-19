using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IU1.Components
{
  public class InputForm : ViewComponent
  {
    //async metod, returnernar vy
    public async Task<IViewComponentResult> InvokeAsync()
    {
      return View();
    }
  }
}
