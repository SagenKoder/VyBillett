using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; }

        public List<LineStation> LineStations { get; set; }

        public override string ToString()
        {
            return "{" + GetType() + ", " + StationId + ", " + Name + "}";
        }
    }
}
