using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VyBillett.Models
{
    public class DbInit : DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db _context)
        {
            var Oslo = new Station { Name = "Oslo" };
            _context.Stations.Add(Oslo);

            // Lillestrøm - Hamar
            var Lillestrøm = new Station { Name = "Lillestrøm" };
            _context.Stations.Add(Lillestrøm);
            var Gardermoen = new Station { Name = "Gardermoen" };
            _context.Stations.Add(Gardermoen);
            var Eidsvoll = new Station { Name = "Eidsvoll" };
            _context.Stations.Add(Eidsvoll);
            var Hamar = new Station { Name = "Hamar" };
            _context.Stations.Add(Hamar);

            var lillestrøm_hamar = new Line { Name = "Lillestrøm - Hamar" };
            _context.Lines.Add(lillestrøm_hamar);
            _context.LineStations.Add(new LineStation { Line = lillestrøm_hamar, Station = Lillestrøm });
            _context.LineStations.Add(new LineStation { Line = lillestrøm_hamar, Station = Gardermoen });
            _context.LineStations.Add(new LineStation { Line = lillestrøm_hamar, Station = Eidsvoll });
            _context.LineStations.Add(new LineStation { Line = lillestrøm_hamar, Station = Hamar });

            // Gøvik-Gøteborg
            var Gjøvik = new Station { Name = "Gjøvik" };
            _context.Stations.Add(Gjøvik);
            var Jaren = new Station { Name = "Jaren" };
            _context.Stations.Add(Jaren);
            // Kobles med Oslo her
            var Ski = new Station { Name = "Ski" };
            _context.Stations.Add(Ski);
            var Moss = new Station { Name = "Moss" };
            _context.Stations.Add(Moss);
            var Halden = new Station { Name = "Halden" };
            _context.Stations.Add(Halden);
            var Gøteborg = new Station { Name = "Gøteborg" };
            _context.Stations.Add(Gøteborg);

            var gøvik_gøteborg = new Line { Name = "Gøvik - Gøteborg" };
            _context.Lines.Add(gøvik_gøteborg);
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Gjøvik });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Jaren });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Oslo });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Ski });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Moss });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Halden });
            _context.LineStations.Add(new LineStation { Line = gøvik_gøteborg, Station = Gøteborg });


            // Larvik - Oslo
            var Larvik = new Station { Name = "Larvik" };
            _context.Stations.Add(Larvik);
            var Tønsberg = new Station { Name = "Tønsberg" };
            _context.Stations.Add(Tønsberg);
            var Drammen = new Station { Name = "Drammen" };
            _context.Stations.Add(Drammen);
            var Asker = new Station { Name = "Asker" };
            _context.Stations.Add(Asker);
            // Oslo

            var larvik_oslo = new Line { Name = "Larvik - Oslo" };
            _context.Lines.Add(larvik_oslo);
            _context.LineStations.Add(new LineStation { Line = larvik_oslo, Station = Larvik, Minutes = 0 });
            _context.LineStations.Add(new LineStation { Line = larvik_oslo, Station = Tønsberg, Minutes = 10 });
            _context.LineStations.Add(new LineStation { Line = larvik_oslo, Station = Drammen, Minutes = 20 });
            _context.LineStations.Add(new LineStation { Line = larvik_oslo, Station = Asker, Minutes = 30 });
            _context.LineStations.Add(new LineStation { Line = larvik_oslo, Station = Oslo, Minutes = 40 });

            // Departures
            _context.Departures.Add(new Departure { Line = larvik_oslo, DateTime = DateTime.Now });
            _context.Departures.Add(new Departure { Line = larvik_oslo, DateTime = DateTime.Now.AddMinutes(10) });
            _context.Departures.Add(new Departure { Line = larvik_oslo, DateTime = DateTime.Now.AddMinutes(20) });
            _context.Departures.Add(new Departure { Line = larvik_oslo, DateTime = DateTime.Now.AddMinutes(30) });
            _context.Departures.Add(new Departure { Line = larvik_oslo, DateTime = DateTime.Now.AddMinutes(40) });

            // Stavanger - Oslo
            var Stavanger = new Station { Name = "Stavanger" };
            _context.Stations.Add(Stavanger);
            var Bryne = new Station { Name = "Bryne" };
            _context.Stations.Add(Bryne);
            var Egersund = new Station { Name = "Egersund" };
            _context.Stations.Add(Egersund);
            var Kristiansand = new Station { Name = "Kristiansand" };
            _context.Stations.Add(Kristiansand);
            var Nelaug = new Station { Name = "Nelaug" };
            _context.Stations.Add(Nelaug);
            var Bø = new Station { Name = "Bø" };
            _context.Stations.Add(Bø);
            var Kongsberg = new Station { Name = "Kongsberg" };
            _context.Stations.Add(Kongsberg);
            // Drammen
            // Asker
            // Oslo

            var stavanger_oslo = new Line { Name = "Stavanger - Oslo" };
            _context.Lines.Add(stavanger_oslo);
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Stavanger, Minutes = 0 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Bryne, Minutes = 10 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Egersund, Minutes = 20 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Kristiansand, Minutes = 30 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Nelaug, Minutes = 40 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Bø, Minutes = 50 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Kongsberg, Minutes = 60 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Drammen, Minutes = 70 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Asker, Minutes = 80 });
            _context.LineStations.Add(new LineStation { Line = stavanger_oslo, Station = Oslo, Minutes = 90 });

            // Bergen - Kongsvinger 
            var Bergen = new Station { Name = "Bergen" };
            _context.Stations.Add(Bergen);
            var Voss = new Station { Name = "Voss" };
            _context.Stations.Add(Voss);
            var Myrdal = new Station { Name = "Myrdal" };
            _context.Stations.Add(Myrdal);
            var Geilo = new Station { Name = "Geilo" };
            _context.Stations.Add(Geilo);
            var Gol = new Station { Name = "Gol" };
            _context.Stations.Add(Gol);
            var Hønefoss = new Station { Name = "Hønefoss" };
            _context.Stations.Add(Hønefoss);
            // Drammen 
            // Asker
            // Oslo 
            // Lillestrøm
            var Kongsvinger = new Station { Name = "Kongsvinger" };
            _context.Stations.Add(Kongsvinger);

            base.Seed(_context);
        }
    }
}