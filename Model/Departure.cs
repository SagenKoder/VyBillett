using System;

namespace Model
{
	public class Departure
	{
        public int DepartureId { get; set; }
        public Line Line { get; set; }
        public DateTime DateTime { get; set; }
    }
}