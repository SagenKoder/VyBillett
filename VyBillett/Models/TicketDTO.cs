using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyBillett.Models
{
    public class TicketDTO
    {
        [Required(ErrorMessage = "Velg en stasjon")]
        [StationExsists]
        public string From { get; set; }
        [Required(ErrorMessage = "Velg en stasjon")]
        [StationExsists]
        public string To { get; set; }
        [Required(ErrorMessage = "Velg en dato")]
        [FromNow]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Velg et tidspunkt")]
        public DateTime Time { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Verdien for {0} må være mellom {1} og {2}.")]
        public int Adult { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Verdien for {0} må være mellom {1} og {2}.")]
        public int Student { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Verdien for {0} må være mellom {1} og {2}.")]
        public int Child { get; set; }
    }

    public class StationExsists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string input = (string)value;
            bool success = false;
            using (var db = new VyDbContext())
            {
                success = db.Stations.Any(s => s.Name.ToLower().Equals(input.ToLower()));

                db.Dispose();
            }

            if (success)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Stasjonen du har valgt finnes ikke");
            }
        }
    }

    public class FromNow : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            System.Diagnostics.Debug.WriteLine("Now: " + DateTime.Now);
            System.Diagnostics.Debug.WriteLine("Value: " + value);
            if (DateTime.Now.Date.CompareTo(value) <= 0)
            {

                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Du må velge dagens dato eller en senere dato. ");
            }
        }
    }
}