using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class DepartureDTO
    {
        public int DepartureId { get; set; }
        public int Lineid { get; set; }
        public int StationFromId { get; set; }
        public int StationToId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}