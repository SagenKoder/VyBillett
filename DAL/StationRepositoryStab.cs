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
            return new Station { StationId = station.StationId, Name = "Oslo S", LineStations = null };
        }

        public bool Delete(int id)
        {
            return id != 0;
        }

        public int Count()
        {
            return 3;
        }

        public List<LineStation> GetFromLineId(int lineId)
        {
            List<LineStation> lineStations = new List<LineStation>();

            //Id, Line, Station, Minute
            lineStations.Add(new LineStation {
                    LineStationId = 0,
                    Station = new Station
                    {
                        StationId = 0, 
                        Name = "Oslo s",
                        LineStations = null
                    },
                    Line = new Line
                    {
                        LineId = 0,
                        Name = "Oslo s - Gardermoen",
                        LineStations = null
                    },
                    Minutes = 0
            });
            lineStations.Add(new LineStation
            {
                LineStationId = 1,
                Station = new Station
                {
                    StationId = 1,
                    Name = "Trondheim",
                    LineStations = null
                },
                Line = new Line
                {
                    LineId = 1,
                    Name = "Gjøvik - Gardermoen",
                    LineStations = null
                },
                Minutes = 10
            });
            lineStations.Add(new LineStation
            {
                LineStationId = 2,
                Station = new Station
                {
                    StationId = 2,
                    Name = "Bergen",
                    LineStations = null
                },
                Line = new Line
                {
                    LineId = 2,
                    Name = "Bergen - Gardermoen",
                    LineStations = null
                },
                Minutes = 20
            });
            return lineStations;

        }

    }
}