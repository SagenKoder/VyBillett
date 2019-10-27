using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using NLog;

namespace BLL
{
    public class StationBLL : IStationBLL
    {
        private readonly IStationRepository _stationRepository;
        private readonly NLog.Logger _logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger _logerror = NLog.LogManager.GetLogger("error");

        public StationBLL()
        {
            _stationRepository = new StationRepository();
        }

        public StationBLL(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public List<Station> GetAllStations()
        {
            return _stationRepository.Get();
        } 

        public Station GetStationFromName(string name)
        {
            return _stationRepository.Get(name);
        }

        public Station GetStationFromId(int id)
        {
            return _stationRepository.Get(id);
        }

        public void DeleteStation(int id)
        {
            _stationRepository.Delete(id);
        }

        public void EditStation(int id, Station station)
        {
            _stationRepository.Edit(id, station);
        }

        public Station Insert(Station station)
        {
            _logerror.Debug("Station name: " + station.Name);
            return _stationRepository.Insert(station);
            
        }

        public int Count()
        {
            return _stationRepository.Count();
        }
    }
}
