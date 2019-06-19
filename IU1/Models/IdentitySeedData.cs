using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IU1.Models
{
  public class IdentitySeedData
  {

    //Fyller databasen med användare/inlogg om databasen inte redan är skapad/innehåller data
    public static async void EnsurePopulated(IApplicationBuilder app)
    {
      RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
      var role = roleManager.Roles;

      if (!role.Any()) {
        var coordinator = new IdentityRole { Name = "Coordinator" };
        await roleManager.CreateAsync(coordinator);

        var investigator = new IdentityRole { Name = "Investigator" };
        await roleManager.CreateAsync(investigator);

        var manager = new IdentityRole { Name = "Manager" };
        await roleManager.CreateAsync(manager);

      }


      UserManager<IdentityUser> userManager = app.ApplicationServices
          .GetRequiredService<UserManager<IdentityUser>>();

      var user = userManager.Users;

      if (user.Any()) return;

      // Adds connection to identity
      var e001 = new IdentityUser("E001");
      var e100 = new IdentityUser("E100");
      var e101 = new IdentityUser("E101");
      var e102 = new IdentityUser("E102");
      var e103 = new IdentityUser("E103");
      var e200 = new IdentityUser("E200");
      var e201 = new IdentityUser("E201");
      var e202 = new IdentityUser("E202");
      var e203 = new IdentityUser("E203");
      var e300 = new IdentityUser("E300");
      var e301 = new IdentityUser("E301");
      var e302 = new IdentityUser("E302");
      var e303 = new IdentityUser("E303");
      var e400 = new IdentityUser("E400");
      var e401 = new IdentityUser("E401");
      var e402 = new IdentityUser("E402");
      var e403 = new IdentityUser("E403");
      var e500 = new IdentityUser("E500");
      var e501 = new IdentityUser("E501");
      var e502 = new IdentityUser("E502");
      var e503 = new IdentityUser("E503");

      // Connects password to user
      await userManager.CreateAsync(e001, "!Pass123");
      await userManager.CreateAsync(e100, "!Pass123");
      await userManager.CreateAsync(e101, "!Pass123");
      await userManager.CreateAsync(e102, "!Pass123");
      await userManager.CreateAsync(e103, "!Pass123");
      await userManager.CreateAsync(e200, "!Pass123");
      await userManager.CreateAsync(e201, "!Pass123");
      await userManager.CreateAsync(e202, "!Pass123");
      await userManager.CreateAsync(e203, "!Pass123");
      await userManager.CreateAsync(e300, "!Pass123");
      await userManager.CreateAsync(e301, "!Pass123");
      await userManager.CreateAsync(e302, "!Pass123");
      await userManager.CreateAsync(e303, "!Pass123");
      await userManager.CreateAsync(e400, "!Pass123");
      await userManager.CreateAsync(e401, "!Pass123");
      await userManager.CreateAsync(e402, "!Pass123");
      await userManager.CreateAsync(e403, "!Pass123");
      await userManager.CreateAsync(e500, "!Pass123");

      // Connects the assigned role with the user
      await userManager.AddToRoleAsync(e001, "Coordinator");
      await userManager.AddToRoleAsync(e100, "Manager");
      await userManager.AddToRoleAsync(e101, "Investigator");
      await userManager.AddToRoleAsync(e102, "Investigator");
      await userManager.AddToRoleAsync(e103, "Investigator");
      await userManager.AddToRoleAsync(e200, "Manager");
      await userManager.AddToRoleAsync(e201, "Investigator");
      await userManager.AddToRoleAsync(e202, "Investigator");
      await userManager.AddToRoleAsync(e203, "Investigator");
      await userManager.AddToRoleAsync(e300, "Manager");
      await userManager.AddToRoleAsync(e301, "Investigator");
      await userManager.AddToRoleAsync(e302, "Investigator");
      await userManager.AddToRoleAsync(e303, "Investigator");
      await userManager.AddToRoleAsync(e400, "Manager");
      await userManager.AddToRoleAsync(e401, "Investigator");
      await userManager.AddToRoleAsync(e402, "Investigator");
      await userManager.AddToRoleAsync(e403, "Investigator");
      await userManager.AddToRoleAsync(e500, "Manager");
      await userManager.AddToRoleAsync(e501, "Investigator");
      await userManager.AddToRoleAsync(e502, "Investigator");
      await userManager.AddToRoleAsync(e503, "Investigator");
    }
  }
}
