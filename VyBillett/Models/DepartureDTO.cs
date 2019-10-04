using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class DepartureDTO
    {
        public int DepartureId { get; set; }
        public Line Line { get; set; }
        public DateTime DateTime { get; set; }
        public Station From { get; set; }
        public Station To { get; set; }
    }
}