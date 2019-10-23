using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbInit : DropCreateDatabaseAlways<VyDbContext>
    {
        protected override void Seed(VyDbContext _context)
        {

            var Adult = new Category { CategoryPrice = 120, CategoryName = "Adult" };
            _context.Categories.Add(Adult);
            var Student = new Category { CategoryPrice = 95, CategoryName = "Student" };
            _context.Categories.Add(Student);
            var Child = new Category { CategoryPrice = 60, CategoryName = "Child" };
            _context.Categories.Add(Child);

            
            var gjovik = new Station() { Name = "Gjøvik" };
            _context.Stations.Add(gjovik);
            var jaren = new Station() { Name = "Jaren" };
            _context.Stations.Add(jaren);
            var hakadal = new Station() { Name = "Hakadal" };
            _context.Stations.Add(hakadal);
            var nittedal = new Station() { Name = "Nittedal" };
            _context.Stations.Add(nittedal);
            var kjelsos = new Station() { Name = "Kjelsås" };
            _context.Stations.Add(kjelsos);
            var oslo_s = new Station() { Name = "Oslo S" };
            /*_context.Stations.Add(oslo_s);
            var lillehammer = new Station() { Name = "Lillehammer" };
            _context.Stations.Add(lillehammer);
            var hamar = new Station() { Name = "Hamar" };
            _context.Stations.Add(hamar);
            var eidsvoll = new Station() { Name = "Eidsvoll" };
            _context.Stations.Add(eidsvoll);
            var oslo_lufthavn = new Station() { Name = "Oslo Lufthavn" };
            _context.Stations.Add(oslo_lufthavn);
            var lillestrom = new Station() { Name = "Lillestrøm" };
            _context.Stations.Add(lillestrom);
            var nationaltheateret = new Station() { Name = "Nationaltheatret" };
            _context.Stations.Add(nationaltheateret);
            var skoyen = new Station() { Name = "Skøyen" };
            _context.Stations.Add(skoyen);
            var lysaker = new Station() { Name = "Lysaker" };
            _context.Stations.Add(lysaker);
            var sandvika = new Station() { Name = "Sandvika" };
            _context.Stations.Add(sandvika);
            var asker = new Station() { Name = "Asker" };
            _context.Stations.Add(asker);
            var drammen = new Station() { Name = "Drammen" };
            _context.Stations.Add(drammen);
            var goteborg = new Station() { Name = "Göteborg" };
            _context.Stations.Add(goteborg);
            var halden = new Station() { Name = "Halden" };
            _context.Stations.Add(halden);
            var moss = new Station() { Name = "Moss" };
            _context.Stations.Add(moss);
            var ski = new Station() { Name = "Ski" };
            _context.Stations.Add(ski);
            var kolbotn = new Station() { Name = "Kolbotn" };
            _context.Stations.Add(kolbotn);
            var holmlia = new Station() { Name = "Holmlia" };
            _context.Stations.Add(holmlia);

            var r30_oslo_s = new Line() { Name = "R30 Oslo S" };
            _context.Lines.Add(r30_oslo_s);
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = gjovik, Minutes = 0 });
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = jaren, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = hakadal, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = nittedal, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = kjelsos, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r30_oslo_s, Station = oslo_s, Minutes = 50 });

            int randomTime = 12;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r30_oslo_s, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }

            var r30_gjovik = new Line() { Name = "R30 Gjøvik" };
            _context.Lines.Add(r30_oslo_s);
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = gjovik, Minutes = 50 });
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = jaren, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = hakadal, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = nittedal, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = kjelsos, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r30_gjovik, Station = oslo_s, Minutes = 0 });

            randomTime = 13;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r30_gjovik, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }

            var r10_drammen = new Line() { Name = "R10 Drammen" };
            _context.Lines.Add(r10_drammen);
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = lillehammer, Minutes = 0 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = hamar, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = eidsvoll, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = oslo_lufthavn, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = lillestrom, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = oslo_s, Minutes = 50 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = nationaltheateret, Minutes = 60 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = skoyen, Minutes = 70 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = lysaker, Minutes = 80 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = sandvika, Minutes = 90 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = asker, Minutes = 100 });
            _context.LineStations.Add(new LineStation() { Line = r10_drammen, Station = drammen, Minutes = 110 });

            randomTime = 14;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r10_drammen, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }

            var r10_lillehammer = new Line() { Name = "R10 Oslo S" };
            _context.Lines.Add(r10_lillehammer);
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = lillehammer, Minutes = 110 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = hamar, Minutes = 100 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = eidsvoll, Minutes = 90 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = oslo_lufthavn, Minutes = 80 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = lillestrom, Minutes = 70 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = oslo_s, Minutes = 60 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = nationaltheateret, Minutes = 50 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = skoyen, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = lysaker, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = sandvika, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = asker, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r10_lillehammer, Station = drammen, Minutes = 0 });

            randomTime = 15;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r10_lillehammer, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }

            var r20_skoyen = new Line() { Name = "R20 Skøyen" };
            _context.Lines.Add(r20_skoyen);
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = goteborg, Minutes = 0 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = halden, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = moss, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = ski, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = kolbotn, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = holmlia, Minutes = 50 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = oslo_s, Minutes = 60 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = nationaltheateret, Minutes = 70 });
            _context.LineStations.Add(new LineStation() { Line = r20_skoyen, Station = skoyen, Minutes = 80 });

            randomTime = 16;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r20_skoyen, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }

            var r20_goteborg = new Line() { Name = "R20 Göteborg" };
            _context.Lines.Add(r20_goteborg);
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = goteborg, Minutes = 80 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = halden, Minutes = 70 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = moss, Minutes = 60 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = ski, Minutes = 50 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = kolbotn, Minutes = 40 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = holmlia, Minutes = 30 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = oslo_s, Minutes = 20 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = nationaltheateret, Minutes = 10 });
            _context.LineStations.Add(new LineStation() { Line = r20_goteborg, Station = skoyen, Minutes = 0 });

            randomTime = 17;
            for (int i = 0; i < 800; i++)
            {
                _context.Departures.Add(new Departure { Line = r20_goteborg, DateTime = DateTime.Now.AddMinutes(i * randomTime) });
            }*/

            base.Seed(_context);
        }
    }
}
