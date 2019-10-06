using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VyBillett.Models
{
    public class DepartureDTO
    {
        public int Departure { get; set; }
        [Required(ErrorMessage = "You need to enter your card number!")]
        [RegularExpression("[0-9]{16}")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "You need to select an expiration month!")]
        [RegularExpression("([1][012])|(0[1-9])")]
        public string CardExpirationMonth { get; set; }
        [Required(ErrorMessage = "You need to select an expiration year!")]
        [RegularExpression("20[0-9]{2}")]
        public string CardExpirationYear { get; set; }
        [Required(ErrorMessage = "You need to select a CVE security code!")]
        [RegularExpression("[0-9]{3}")]
        public string CVE { get; set; }
    }
}
