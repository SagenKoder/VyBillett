using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VyBillett.Models
{
    public class Line
    {
        public int LineId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<LineStation> LineStations { get; set; }
    }
}