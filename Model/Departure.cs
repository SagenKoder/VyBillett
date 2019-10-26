using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Departure
    {
        public int DepartureId { get; set; }
        public Line Line { get; set; }
        public DateTime DateTime { get; set; }

    }
}
