using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IU1.Components
{
    public class ShowOneCrime: ViewComponent
    {
      private InterfaceRepository mymodel;

      //Konstruktor för ShowOneCrime komponent
      public ShowOneCrime(InterfaceRepository mymode)
      {
        mymodel = mymode;
      }
      
      //async metod, returnernar vy med relevant brott beroende på vilet brott som valts
      public async Task<IViewComponentResult> InvokeAsync(String id)
      {
        var objectOfCrime = await mymodel.GetOneCase(id);
        return View(objectOfCrime);
      }
    }
}
