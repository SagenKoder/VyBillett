using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class TravelDeparture
    {
        public Station StationFrom { get; set; }
        public Station StationTo { get; set; }
        public Departure Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
