using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IU1.Controllers
{
  public class AccountController : Controller
  {
    private UserManager<IdentityUser> userManager;
    private SignInManager<IdentityUser> signInManager;

    //Konstruktor
    public AccountController(UserManager<IdentityUser> userMgr,
      SignInManager<IdentityUser> signInMgr)
    {
      userManager = userMgr;
      signInManager = signInMgr;
    }
    // GET: /<controller>/


    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
      if (ModelState.IsValid) {
        IdentityUser user =
          await userManager.FindByNameAsync(loginModel.Name);
        if (user != null) {
          await signInManager.SignOutAsync();
          if ((await signInManager.PasswordSignInAsync(user,
            loginModel.Password, false, false)).Succeeded) {
            if (await userManager.IsInRoleAsync(user, "Manager"))
            {
              return Redirect(loginModel?.ReturUrl ?? "/Manager/StartManager");
            }
            if (await userManager.IsInRoleAsync(user, "Coordinator")) {
              return Redirect(loginModel?.ReturUrl ?? "/Coordinator/StartCoordinator");
            }
            if (await userManager.IsInRoleAsync(user, "Investigator")) {
              return Redirect(loginModel?.ReturUrl ?? "/Investigator/StartInvestigator");
            }

          }
        }
      }
      ModelState.AddModelError("", "Invalid name or password");
      return View(loginModel);
    }

    [AllowAnonymous]
    public ViewResult Login(string returnUrl)
    {
      return View(new LoginModel {
        ReturUrl = returnUrl
      });
    }

    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
      var message = new LoginModel();
      ModelState.AddModelError("", "Åtkomst nekad");
      return View(message);
    }

    //Logout
    public async Task<RedirectResult> Logout(string returnUrl = "/")
    {
      await signInManager.SignOutAsync();
      return Redirect(returnUrl);
    }
  }
}
