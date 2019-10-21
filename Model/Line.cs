using System.Collections.Generic;

namespace Model
{
    public class Line
    {
        public int LineId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<LineStation> LineStations { get; set; }
    }
}