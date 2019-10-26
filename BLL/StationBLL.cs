using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using NLog;

namespace BLL
{
    public class StationBLL : IStationLogic
    {
        private readonly IStationRepository _db;
        private readonly NLog.Logger _logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger _logerror = NLog.LogManager.GetLogger("error");

        public StationBLL()
        {
            _db = new StationRepository();
        }

        public StationBLL(IStationRepository db)
        {
            _db = db;
        }

        public List<Station> GetAllStations()
        {
            return _db.Get();
        } 

        public Station GetStationFromName(string name)
        {
            return _db.Get(name);
        }

        public Station GetStationFromId(int id)
        {
            return _db.Get(id);
        }

        public void DeleteStation(int id)
        {
            _db.Delete(id);
        }

        public void EditStation(int id, Station station)
        {
            _db.Edit(id, station);
        }

        public Station Insert(Station station)
        {
            _logerror.Debug("Station name: " + station.Name);
            return _db.Insert(station);
            
        }

        public int Count()
        {
            return _db.Count();
        }
    }
}
