using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IU1.Models
{
  public class Case
  {

    //Vanlig text räcker i kontrollerna förutom mob.nr. samt datum

    public String ID { get; set; }
    public String RefNumber { get; set; }

    [Required(ErrorMessage = "Du måste fylla i en plats")]
    [Display(Name = "Var har brottet skett någonstans?")]
    public String Place { get; set; }

    [Required(ErrorMessage = "Du måste fylla i ett typ av brott")]
    [Display(Name = "Vilken typ av brott?")]
    public String TypeOfCrime { get; set; }

    //Fungerar tyvärr inte i alla webbläsare. Tvingar användaren att välja datum via applyformatineditmode så att användaren inte kan välja felaktigt
    [Required(ErrorMessage = "Ett datum måste anges")]
    [Display(Name = "Brottsinträffande:")]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfObservation { get; set; }

    [Display(Name = "Beskriv din observation (ex. namn på misstänkt person):")]
    public String Observation { get; set; }

    
    public String Info { get; set; }
    public String Action { get; set; }

    [Required(ErrorMessage = "Du måste fylla i ditt namn")]
    [Display(Name = "Ditt namn (för- och efternamn):")]
    public String InformerName { get; set; }

    //Validerar att telefonnummer som anges är enl. errormessage
    [Required(ErrorMessage = "Telefonnummer måste anges")]
    [RegularExpression(pattern: @"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$",
      ErrorMessage = "Formatet för mobilnummer ska vara 0xxx-xxxxxx")]
    [Display(Name = "Din telefon:")]
    public String InformerPhone { get; set; }
    public String Status { get; set; }
    public String Department { get; set; }
    public String Employee { get; set; }

  }
}
