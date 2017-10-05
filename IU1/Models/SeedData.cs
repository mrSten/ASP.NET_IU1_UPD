using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IU1.Models
{
  public class SeedData
  {
    public static void EnsurePopulated(IApplicationBuilder app)
    {
      ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
      if (!context.Cases.Any())
      {
        context.Cases.AddRange(
          new Case
          {
            RefNumber = "2017-45-",
            Place = "Skogslunden vid Jensens gård",
            TypeOfCrime = "Sopor",
            DateOfObservation = new DateTime(2017, 04, 24),
            Observation = "Anmälaren var på promenad i skogslunden när hon upptäckte soporna",
            Info = "Undersökning har gjorts och bland soporna hittades bl.a ett brev till Gösta Olsson",
            Action = "Brev har skickats till Gösta Olsson om soporna och anmälan har gjorts till polisen 2017-05-10",
            InformerName = "Ada Bengtsson",
            InformerPhone = "0432-5545522",
            Status = "Klar",
            Department = "Renhållning och avfall",
            Employee = "Susanne Fred"
          },
          new Case
          {
            RefNumber = "2017-45-0002",
            Place = "Småstadsjön",
            TypeOfCrime = "Oljeutsläpp",
            DateOfObservation = new DateTime(2017, 04, 29),
            Observation = "Jag såg en oljefläck på vattnet när jag var där för att fiska",
            Info = "Undersökning gjorts på plats, ingen fläck har hittats",
            Action = "",
            InformerName = "Bengt Svensson",
            InformerPhone = "0432-5152255",
            Status = "Ingen åtgärd",
            Department = "Natur och Skogsvård",
            Employee = "Oskar Ivarsson"
          },
          new Case
          {
            RefNumber = "2017-45-0003",
            Place = "Odehuset",
            TypeOfCrime = "Skrot",
            DateOfObservation = new DateTime(2017, 05, 02),
            Observation = "Anmälaren körde förbi ödehuset och upptäckte ett antal bilar och annat skrot",
            Info = "Undersökning har gjorts och bilder har tagits",
            Action = "",
            InformerName = "Olle Pettersson",
            InformerPhone = "0432-5255522",
            Status = "Påbörjad",
            Department = "Miljö och Hälsoskydd",
            Employee = "Lena Larsson"
          },
          new Case
          {
            RefNumber = "2017-45-0004",
            Place = "Restaurang Krögaren",
            TypeOfCrime = "Buller",
            DateOfObservation = new DateTime(2017, 06, 04),
            Observation = "Restaurang hade för högt ljud på så man kunde inte sova",
            Info = "Bullermätning har gjorts. Håller sig inom riktvärden",
            Action = "Meddelat restaurangen att tänka på ljudet i fortsättningen",
            InformerName = "Roland Jönsson",
            InformerPhone = "0432-5322255",
            Status = "Klar",
            Department = "Miljö och Hälsoskydd",
            Employee = "Martin Kvist"
          },
          new Case
          {
            RefNumber = "2017-45-0005",
            Place = "Torget",
            TypeOfCrime = "Klotter",
            DateOfObservation = new DateTime(2017, 07, 10),
            Observation = "Samtliga Skräpkorgar och bänkar är nedklottrade",
            Info = "",
            Action = "",
            InformerName = "PEtter Svensson",
            InformerPhone = "0432-5322555",
            Status = "Inrapporterad",
            Department = "Ej tilsatt",
            Employee = "Ej tillsatt"
          });
        context.Departments.AddRange(
          new Department
          {
            DepartmentID = "1",
            DepartmentName = "Småstads Kommun"
          },
          new Department
          {
            DepartmentID = "2",
            DepartmentName = "IT-avdelningen"
          },
          new Department
          {
            DepartmentID = "3",
            DepartmentName = "Lek och Skoj"
          },
          new Department
          {
            DepartmentID = "4",
            DepartmentName = "Miljöskydd"
          });
        context.Employees.AddRange(
          new Employee
          {
            EmployeeID = "1",
            EmployeeName = "Martin Kvist",
            Department = "Småstads Kommun",
            RoleTitle = "Citizen"
          },
          new Employee
          {
            EmployeeID = "2",
            EmployeeName = "Lena Larsson",
            Department = "IT-avdelningen",
            RoleTitle = "Coordinator"
          },
          new Employee
          {
            EmployeeID = "3",
            EmployeeName = "Oskar Ivarsson",
            Department = "Lek och Skoj",
            RoleTitle = "Investigator"
          },
          new Employee
          {
            EmployeeID = "4",
            EmployeeName = "Susanne Fred",
            Department = "Miljöskydd",
            RoleTitle = "Manager"
          });
        context.Statuses.AddRange(
          new Status
          {
            StatusID = "1",
            StatusName = "Rapporterad"
          }, new Status
          {
            StatusID = "2",
            StatusName = "Ingen åtgärd"
          },
          new Status
          {
            StatusID = "3",
            StatusName = "Startad"
          },
          new Status
          {
            StatusID = "4",
            StatusName = "Färdig"
          });
        context.SaveChanges();
      }
    }
  }
}

