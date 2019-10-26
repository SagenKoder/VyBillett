using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartureRepository
    {

        public int Count()
        {
            using (var db = new VyDbContext())
            {
                return db.Departures.Count();
            }
        }

        public List<Departure> Get()
        {
            using (var db = new VyDbContext())
            {
                var departures = db.Departures.OrderBy(x => x.DateTime).ToList();
               
                return departures;
            }
        }

        public List<Departure> GetFromLineId(int lineId)
        {
            using (var db = new VyDbContext())
            {
                var departures = db.Departures.Where(x => x.Line.LineId == lineId).OrderBy(x => x.DateTime).ToList();
                return departures;
            }

        }

        public Departure Insert(Departure departure)
        {
            using (var db = new VyDbContext())
            {
                var inserted = db.Departures.Add(departure);
                db.SaveChanges();
                
                return inserted;
            }
        }

   
    }
}
