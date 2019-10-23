using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class StationRepository : IStationRepository
    {
        public List<Station> Get()
        {
            using(var db = new VyDbContext())
            {
                return db.Stations.OrderBy(s => s.Name).ToList();
            }
        }

        public Station Get(int id)
        {
            using (var db = new VyDbContext())
            {
                return db.Stations.Where(i => i.StationId == id).FirstOrDefault();
            }
        }
        public Station Get(string name)
        {
            using (var db = new VyDbContext())
            {
                return db.Stations.Where(i => i.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
            }
        }

        public bool Edit(int id, Station station)
        {
            using (var db = new VyDbContext())
            {
                // Finds the Station from the database
                // TODO: Test if this one work! The example wasn't clear
                try
                {
                    // FirstOrDefault throws an Exception if it doesn't find a Station
                    Station stationToChange = db.Stations.FirstOrDefault(s => s.StationId == id);
                    stationToChange.Name = station.Name;
                    stationToChange.LineStations = station.LineStations;

                    db.SaveChanges();
                    return true;
                } 
                catch 
                {
                    return false;
                }
            }
        }

        public bool Insert(Station station)
        {
            // TODO: Validate the station before inserting to DB

            // Checks that there's no StationId allready set. Cloud create an error when inserting it in the database
            if (station.StationId == default)
            {
                return false;
            }
            if(station.Name.Equals(""))
            {
                return false;
            }
            
            using(var db = new VyDbContext())
            {
                db.Stations.Add(station);
                db.SaveChanges();
            }

            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                Station station = db.Stations.Find(id);
                if (station == null)
                {
                    // Find() returns null if there's no Stations
                    return false;
                }
                db.Stations.Remove(station);
                db.SaveChanges();
                return true;
            }
        }
    }
}
