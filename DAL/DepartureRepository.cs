using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartureRepository : IDepartureRepository
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");
        private readonly string repositoryName = "DeparturesRepository";

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

        public Departure GetFromId(int id)
        {
            using (var db = new VyDbContext())
            {
               
                return db.Departures.Find(id);
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

        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                var departure = db.Departures.Find(id);
                if (departure == null)
                {
                    logdb.Error("{Repository} Delete({null})", repositoryName, id);
                    return false;
                }
                db.Departures.Remove(departure);
                db.SaveChanges();
                logdb.Info("{Repository} Delete({null})", repositoryName, id);
                return true;
            }
        }


    }
}
