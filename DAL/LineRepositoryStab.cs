using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class LineRepositoryStab : ILineRepository
    {

        public List<Line> Get()
        {
            IStationRepository stationRepository = new StationRepositoryStab();
            List<Line> lines = new List<Line>();
            for(int i = 1; i <= 10; i++)
            {
                var line = new Line();
                line.LineId = i;
                line.Name = "Line " + i;
                line.LineStations = new List<LineStation>();
                int num = 1;
                foreach (Station station in stationRepository.Get())
                {
                    line.LineStations.Add(new LineStation { 
                        LineStationId = num++ * i, 
                        Line = line, 
                        Station = station, 
                        Minutes = num * 10 
                    });
                }
            }
            return lines;
        }

        public Line Get(int id)
        {
            IStationRepository stationRepository = new StationRepositoryStab();

            var line = new Line();
            line.LineId = id;
            line.Name = "Line " + id;
            line.LineStations = new List<LineStation>();
            int num = 1;
            foreach (Station station in stationRepository.Get())
            {
                line.LineStations.Add(new LineStation
                {
                    LineStationId = num++ * id,
                    Line = line,
                    Station = station,
                    Minutes = num * 10
                });
            }

            return line;
        }

        public Line Get(string name)
        {
            IStationRepository stationRepository = new StationRepositoryStab();

            var line = new Line();
            line.LineId = 5;
            line.Name = name;
            line.LineStations = new List<LineStation>();
            int num = 1;
            foreach (Station station in stationRepository.Get())
            {
                line.LineStations.Add(new LineStation
                {
                    LineStationId = num++ * 5,
                    Line = line,
                    Station = station,
                    Minutes = num * 10
                });
            }

            return line;
        }

        public bool Edit(int id, Line line)
        {
            line.LineId = id;
            return true;
        }

        public Line Insert(Line line)
        {
            line.LineId = 5;
            return line;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public int Count()
        {
            return 10;
        }
    }
}