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
    //Fyller databasen med fake-info om databasen inte redan är skapad/innehåller data
    public static void EnsurePopulated(IApplicationBuilder app)
    {
      ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
      if (!context.Cases.Any()) {
        context.Cases.AddRange(
          new Case {
            RefNumber = "2017-45-0001",
            Place = "Skogslunden vid Jensens gård",
            TypeOfCrime = "Sopor",
            DateOfObservation = new DateTime(2017, 04, 24),
            Observation = "Anmälaren var på promenad i skogslunden när hon upptäckte soporna",
            Info = "Undersökning har gjorts och bland soporna hittades bl.a ett brev till Gösta Olsson",
            Event = "Brev har skickats till Gösta Olsson om soporna och anmälan har gjorts till polisen 2017-05-10",
            InformerName = "Ada Bengtsson",
            InformerPhone = "0432-5545522",
            Status = "Klar",
            Department = "Renhållning och avfall",
            Employee = "Susanne Fred"
          },
          new Case {
            RefNumber = "2017-45-0002",
            Place = "Småstadsjön",
            TypeOfCrime = "Oljeutsläpp",
            DateOfObservation = new DateTime(2017, 04, 29),
            Observation = "Jag såg en oljefläck på vattnet när jag var där för att fiska",
            Info = "Undersökning gjorts på plats, ingen fläck har hittats",
            Event = "",
            InformerName = "Bengt Svensson",
            InformerPhone = "0432-5152255",
            Status = "Ingen åtgärd",
            Department = "Natur och Skogsvård",
            Employee = "Oskar Ivarsson"
          },
          new Case {
            RefNumber = "2017-45-0003",
            Place = "Odehuset",
            TypeOfCrime = "Skrot",
            DateOfObservation = new DateTime(2017, 05, 02),
            Observation = "Anmälaren körde förbi ödehuset och upptäckte ett antal bilar och annat skrot",
            Info = "Undersökning har gjorts och bilder har tagits",
            Event = "",
            InformerName = "Olle Pettersson",
            InformerPhone = "0432-5255522",
            Status = "Påbörjad",
            Department = "Miljö och Hälsoskydd",
            Employee = "Lena Larsson"
          },
          new Case {
            RefNumber = "2017-45-0004",
            Place = "Restaurang Krögaren",
            TypeOfCrime = "Buller",
            DateOfObservation = new DateTime(2017, 06, 04),
            Observation = "Restaurang hade för högt ljud på så man kunde inte sova",
            Info = "Bullermätning har gjorts. Håller sig inom riktvärden",
            Event = "Meddelat restaurangen att tänka på ljudet i fortsättningen",
            InformerName = "Roland Jönsson",
            InformerPhone = "0432-5322255",
            Status = "Klar",
            Department = "Miljö och Hälsoskydd",
            Employee = "Martin Kvist"
          },
          new Case {
            RefNumber = "2017-45-0005",
            Place = "Torget",
            TypeOfCrime = "Klotter",
            DateOfObservation = new DateTime(2017, 07, 10),
            Observation = "Samtliga Skräpkorgar och bänkar är nedklottrade",
            Info = "",
            Event = "",
            InformerName = "PEtter Svensson",
            InformerPhone = "0432-5322555",
            Status = "Inrapporterad",
            Department = "Ej tilsatt",
            Employee = "Ej tillsatt"
          });
        context.Departments.AddRange(
          new Department {
            DepartmentID = "D00",
            DepartmentName = "Småstads Kommun"
          },
          new Department {
            DepartmentID = "D01",
            DepartmentName = "Tekniska Avloppshanteringen"
          },
          new Department {
            DepartmentID = "D02",
            DepartmentName = "Klimat och Energi"
          },
          new Department {
            DepartmentID = "D03",
            DepartmentName = "Miljö och Hälsoskydd"
          },
          new Department {
            DepartmentID = "D04",
            DepartmentName = "Natur och Skogsvård"
          },
          new Department {
            DepartmentID = "D05",
            DepartmentName = "Renhållning och Avfall"
          });
        context.Employees.AddRange(
          new Employee { EmployeeID = "E001", EmployeeName = "Östen Ärling", RoleTitle = "coordinator", Department = "Småstads Kommun" },
          new Employee { EmployeeID = "E100", EmployeeName = "Anna Åkerman", RoleTitle = "manager", Department = "Tekniska Avloppshanteringen" },
          new Employee { EmployeeID = "E101", EmployeeName = "Fredrik Roos", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },
          new Employee { EmployeeID = "E102", EmployeeName = "Gösta Qvist", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },
          new Employee { EmployeeID = "E103", EmployeeName = "Hilda Persson", RoleTitle = "investigator", Department = "Tekniska Avloppshanteringen" },
          new Employee { EmployeeID = "E200", EmployeeName = "Bengt Viik", RoleTitle = "manager", Department = "Klimat och Energi" },
          new Employee { EmployeeID = "E201", EmployeeName = "Ivar Oscarsson", RoleTitle = "investigator", Department = "Klimat och Energi" },
          new Employee { EmployeeID = "E202", EmployeeName = "Jenny Nordström", RoleTitle = "investigator", Department = "Klimat och Energi" },
          new Employee { EmployeeID = "E203", EmployeeName = "Kurt Mild", RoleTitle = "investigator", Department = "Klimat och Energi" },
          new Employee { EmployeeID = "E300", EmployeeName = "Cecilia Unosson", RoleTitle = "manager", Department = "Miljö och Hälsoskydd" },
          new Employee { EmployeeID = "E301", EmployeeName = "Lena Larsson", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },
          new Employee { EmployeeID = "E302", EmployeeName = "Martin Kvist", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },
          new Employee { EmployeeID = "E303", EmployeeName = "Nina Jansson", RoleTitle = "investigator", Department = "Miljö och Hälsoskydd" },
          new Employee { EmployeeID = "E400", EmployeeName = "David Trastlund", RoleTitle = "manager", Department = "Natur och Skogsvård" },
          new Employee { EmployeeID = "E401", EmployeeName = "Oskar Ivarsson", RoleTitle = "investigator", Department = "Natur och Skogsvård" },
          new Employee { EmployeeID = "E402", EmployeeName = "Petra Hermansdotter", RoleTitle = "investigator", Department = "Natur och Skogsvård" },
          new Employee { EmployeeID = "E403", EmployeeName = "Rolf Gunnarsson", RoleTitle = "investigator", Department = "Natur och Skogsvård" },
          new Employee { EmployeeID = "E500", EmployeeName = "Emma Svanberg", RoleTitle = "manager", Department = "Renhållning och Avfall" },
          new Employee { EmployeeID = "E501", EmployeeName = "Susanne Fred", RoleTitle = "investigator", Department = "Renhållning och Avfall" },
          new Employee { EmployeeID = "E502", EmployeeName = "Torsten Embjörn", RoleTitle = "investigator", Department = "Renhållning och Avfall" },
          new Employee { EmployeeID = "E503", EmployeeName = "Ulla Davidsson", RoleTitle = "investigator", Department = "Renhållning och Avfall" });
        context.Statuses.AddRange(
          new Status {
            StatusID = "S_A",
            StatusName = "Rapporterad"
          }, new Status {
            StatusID = "S_B",
            StatusName = "Ingen åtgärd"
          },
          new Status {
            StatusID = "S_C",
            StatusName = "Startad"
          },
          new Status {
            StatusID = "S_D",
            StatusName = "Färdig"
          });
        context.SaveChanges();
      }
    }
  }
}

