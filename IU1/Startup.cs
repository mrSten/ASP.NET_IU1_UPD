using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IU1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IU1
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    private IConfigurationRoot Configuration;

    public Startup(IHostingEnvironment env)
    {
      Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json")
        .Build();
    }


    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration["Data:EnviromentCrimesData:ConnectionString"]));
      services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(Configuration["Data:EnviromentIdentityData:ConnectionString"]));
      services.AddIdentity<IdentityUser, IdentityRole>(opts => {
        opts.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
        opts.Cookies.ApplicationCookie.AccessDeniedPath = "/Account/AccessDenied";
      }).AddEntityFrameworkStores<AppIdentityDBContext>();
      services.AddTransient<InterfaceRepository, EFRepository>();

      services.AddMvc();
      services.AddSession();
      //old: services.AddTransient<InterfaceRepository, FakeModelRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {

      //Developer tools, tas bort före release
      app.UseDeveloperExceptionPage();
      app.UseStatusCodePages();
      //Session Initialize
      app.UseSession();
      //Identity Initialize
      app.UseIdentity();
      //Static for page
      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();

      //Initializing DB (cases)
      SeedData.EnsurePopulated(app);

      //Initializing DB (identitys)
      IdentitySeedData.EnsurePopulated(app);
    }
  }
}
