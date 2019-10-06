using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VyBillett.Models
{
    public class DepartureDTO
    {
        [RegularExpression("[0-9]{1,2}", ErrorMessage = "Du må velge en avgang!")]
        public int Departure { get; set; }
        [Required(ErrorMessage = "Du må skrive inn kortnummer!")]
        [DataType(DataType.CreditCard, ErrorMessage = "Du må skrive inn et gyldig kortnummer!")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Du må skrive inn utløps-måned!")]
        [RegularExpression("([1][012])|(0[1-9])", ErrorMessage = "Du må velge en måned (01 - 12)")]
        public string CardExpirationMonth { get; set; }
        [Required(ErrorMessage = "Du må skrive inn utløps-år!")]
        [RegularExpression("20[0-9]{2}", ErrorMessage = "Du må velge ett år (2020)!")]
        public string CardExpirationYear { get; set; }
        [Required(ErrorMessage = "Du må skrive inn en CVE!")]
        [RegularExpression("[0-9]{3}", ErrorMessage = "Du må skrive inn en CVE (3 tall)")]
        public string CVE { get; set; }
    }
}
