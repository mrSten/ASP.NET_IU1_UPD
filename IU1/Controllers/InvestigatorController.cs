using System;
using System.IO;
using System.Linq;
using IU1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  [Authorize(Roles = "Investigator")]
  public class InvestigatorController : Controller
  {
    private InterfaceRepository mymodel;
    private IHostingEnvironment environment;

    //Konstruktor
    public InvestigatorController(InterfaceRepository mymode, IHostingEnvironment envi)
    {
      mymodel = mymode;
      environment = envi;
    }
    // GET: /<controller>/
    //Uppdaterar information om ett case som läggs in av Investigator. Kopplar också bilder/samples till caset samt laddar upp dem till DB
    public IActionResult UpdateCase(String events, String information, Status status, String id, IFormFile loadSample, IFormFile loadImage)
    {
      Case tempCase = mymodel.ReturnOneCase(id);

      try {
        var filePathSample = Path.Combine(environment.WebRootPath, "Samples", loadSample.FileName);
        ViewBag.Path = filePathSample;
        if (loadSample.Length > 0) {
          using (var stream = new FileStream(filePathSample, FileMode.Create)) {
            loadSample.CopyToAsync(stream);
            stream.Dispose();
          }
        }

        Sample tempSample = new Sample();
        tempSample.CaseID = tempCase.ID;
        tempSample.SampleName = loadSample.FileName;
        tempCase.Samples.Add(tempSample);
      } catch (Exception e) {

      }
      try {
        var filePathImage = Path.Combine(environment.WebRootPath, "Pictures", loadImage.FileName);
        ViewBag.Path = filePathImage;
        if (loadImage.Length > 0) {
          using (var stream = new FileStream(filePathImage, FileMode.Create)) {
            loadImage.CopyToAsync(stream);
            stream.Dispose();
          }
        }
        Picture tempPicture = new Picture();
        tempPicture.CaseID = tempCase.ID;
        tempPicture.PictureName = loadImage.FileName;
        tempCase.Pictures.Add(tempPicture);
      } catch (Exception ee) {

      }
      try {
        if (events.Count() != 0) {
          tempCase.Event += "\n" + events;
        }
      } catch (Exception eee) {
        //ingen event parameter inskickad
      }
      try {
        if (information.Count() != 0) {
          tempCase.Info += "\n" + information;
        }
      } catch (Exception eeee) {
        //ingen information parameter inskickad
      }



      if (!status.StatusName.Equals("Välj")) { //Något måste vara valt
        tempCase.Status = status.StatusName;
      }


      mymodel.SaveCase(tempCase); //sparar information och koppling i DB



      return RedirectToAction("StartInvestigator"); //Återvänder till StartInvestigator
    }
    public IActionResult CrimeInvestigator(String id)
    {
      ViewBag.User = mymodel.RelevantUser();
      ViewBag.ListOfStatuses = mymodel.Statuses;
      ViewBag.TId = id;
      return View();
    }
    public IActionResult StartInvestigator()
    {
      ViewBag.User = mymodel.RelevantUser();
      return View(mymodel);
    }
  }
}
