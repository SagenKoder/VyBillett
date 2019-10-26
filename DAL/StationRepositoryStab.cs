using System.Collections.Generic;
using Model;

namespace DAL
{
    public class StationRepositoryStab : IStationRepository
    {
        public List<Station> Get()
        {
            var stations = new List<Station>();
            var oslos = new Station {StationId = 0, Name = "Oslo S", LineStations = null};
            
            stations.Add(oslos);
            stations.Add(oslos);
            stations.Add(oslos);

            return stations;
        }

        public Station Get(int id)
        {
            return id == 0 ? null : new Station { StationId = 0, Name = "Oslo S", LineStations = null };
        }

        public Station Get(string name)
        {
            return name == "" ? null : new Station { StationId = 0, Name = "Oslo S", LineStations = null };
        }

        public bool Edit(int id, Station station)
        {
            // TODO: Add validation to station
            return id != 0;
        }

        public Station Insert(Station station)
        {
            if (station.Name == null)
            {
                return null;
            }
            return new Station { StationId = 0, Name = "Oslo S", LineStations = null };
        }

        public bool Delete(int id)
        {
            return id != 0;
        }

        public int Count()
        {
            return 3;
        }
    }
}