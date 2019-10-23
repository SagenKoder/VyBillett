using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class User
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public string Password { get; set; }
    }
}
