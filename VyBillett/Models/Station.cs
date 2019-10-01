using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; }

        public List<LineStation> LineStations { get; set; }


    }
}