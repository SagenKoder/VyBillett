using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Station From { get; set; }
        public Station To { get; set; }
        public Departure Departure { get; set; }
    }
}