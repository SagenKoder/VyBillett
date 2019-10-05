using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class TicketDTO
    {
        [Required(ErrorMessage = "Velg en stasjon")]
        public string From { get; set; }
        [Required(ErrorMessage = "Velg en stasjon")]
        public string To { get; set; }
        [Required(ErrorMessage = "Velg en dato")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Velg et tidspunkt")]
        public DateTime Time { get; set; }
        public Line Line { get; set; }
        public int Adult { get; set; }
        public int Student { get; set; }
        public int Child { get; set; }
    }
}