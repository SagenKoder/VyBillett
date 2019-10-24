using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StationBLL
    {
        StationRepository db = new StationRepository();
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        public List<Station> GetAllStations()
        {
            return db.Get();
        } 

        public Station GetStationFromName(string name)
        {
            return db.Get(name);
        }

        public void DeleteStation(int id)
        {
            db.Delete(id);
        }

        public void EditStation(int id, Station station)
        {
            db.Edit(id, station);
        }
    }
}
