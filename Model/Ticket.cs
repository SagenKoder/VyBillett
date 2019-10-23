using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public Station From { get; set; }
        public Station To { get; set; }
        public Departure Departure { get; set; }
        public int Price { get; set; }
        public int NumAdult { get; set; }
        public int NumStudent { get; set; }
        public int NumChild { get; set; }
        public DateTime Date { get; set; }
    }
}
