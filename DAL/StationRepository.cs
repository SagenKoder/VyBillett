using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DAL
{
    public class StationRepository : IStationRepository
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");
        private readonly string repositoryName = "StationsRepository";

        public List<Station> Get()
        {
            using(var db = new VyDbContext())
            {
                var stations = db.Stations.OrderBy(s => s.Name).ToList();
                logdb.Info("{Repository} Get(): {0} stations", repositoryName, stations.Count);
                foreach (var station in stations)
                {
                    logdb.Info("\tAccessed: {0}", station.ToString());
                }
                
                return stations;
            }
        }

        public Station Get(int id)
        {
            using (var db = new VyDbContext())
            {
                var station = db.Stations.Single(i => i.StationId == id);
                logdb.Info("{Repository} Get({-1}): {0}", repositoryName, id, station.ToString());
                return station;
            }
        }

        public Station Get(string name)
        {
            using (var db = new VyDbContext())
            {
                try
                {
                    var station = db.Stations.FirstOrDefault(i => i.Name.ToLower().Equals(name.ToLower()));
                    logdb.Info("{Repository} Get({null}): {0}", repositoryName, name, station.ToString());
                    return station;
                }
                catch (Exception)
                {
                    logdb.Error("{Repository} Get({null})", repositoryName, name);
                }
                return null;
            }
        }

        public bool Edit(int id, Station station)
        {
            using (var db = new VyDbContext())
            {
                // Finds the Station from the database
                // TODO: Test if this one work! The example wasn't clear
                var stationToChange = db.Stations.First(s => s.StationId == id);
                if (stationToChange == null)
                {
                    logdb.Error("{Repository} Edit: id={null}", repositoryName, id);
                    return false;
                }
                stationToChange.Name = station.Name;
                //stationToChange.LineStations = station.LineStations;

                logdb.Info("{Repository} Edit({null}): {0}", repositoryName, id, station.ToString());
                db.SaveChanges();
                return true;
            }
        }

        public Station Insert(Station station)
        {
            using(var db = new VyDbContext())
            {
                logdb.Info("{Repository} Insert: {0}", repositoryName, station.ToString());
                var inserted = db.Stations.Add(station);
                db.SaveChanges();
                return inserted;
            }
        }

        // TODO: Delete all references to the Station when deleting!
        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                var station = db.Stations.Find(id);
                if (station == null)
                {
                    logdb.Error("{Repository} Delete({null})", repositoryName, id);
                    return false;
                }
                db.Stations.Remove(station);
                logdb.Info("{Repository} Delete({null})", repositoryName, id);
                db.SaveChanges();
                return true;
            }
        }

        public int Count()
        {
            using (var db = new VyDbContext())
            {
                return db.Stations.Count();
            }
        }

        public List<LineStation> GetFromLineId(int lineId)
        {
            using (var db = new VyDbContext())
            {
                System.Diagnostics.Debug.WriteLine("lineID: " + lineId);
                var lineStations = db.LineStations
                    .Where(x => x.Line.LineId == lineId)
                    .Include(l => l.Line)
                    .Include(s => s.Station)
                    .ToList();
                return lineStations;
            }

        }
    }
}
