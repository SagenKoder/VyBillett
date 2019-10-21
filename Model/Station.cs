using System.Collections.Generic;

namespace Model
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; }

        public List<LineStation> LineStations { get; set; }
    }
}