using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class StatisticsDTO
    {
        [Display(Name = "Users")]
        public int NumUsers { get; set; }
        [Display(Name = "Stations")]
        public int NumStations { get; set; }
        [Display(Name = "Lines")]
        public int NumLines { get; set; }
        [Display(Name = "Departures")]
        public int NumDepartures { get; set; }
        [Display(Name = "Tickets")]
        public int NumTickets { get; set; }
    }
}
