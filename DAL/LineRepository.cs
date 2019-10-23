using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class LineRepository : ILineRepository
    {
        public List<Line> Get()
        {
            using (var db = new VyDbContext())
            {
                return db.Lines.ToList();
            }
        }

        public Line Get(int id)
        {
            using (var db = new VyDbContext())
            {
                return db.Lines.Find(id);
            }
        }

        public Line Get(string name)
        {
            using (var db = new VyDbContext())
            {
                return db.Lines.FirstOrDefault(l => l.Name.Equals(name));
            }
        }

        public bool Edit(int id, Line line)
        {
            using (var db = new VyDbContext())
            {
                // Finds the Station from the database
                // TODO: Test if this one work! The example wasn't clear
                var lineToChange = db.Lines.First(s => s.LineId == id);
                if (lineToChange == null)
                {
                    return false;
                }

                if (lineToChange.Name.Equals(""))
                {
                    return false;
                }
                lineToChange.Name = line.Name;
                
                if (lineToChange.Price == default)
                {
                    return false;
                }
                lineToChange.Price = line.Price;

                if (lineToChange.LineStations == null)
                {
                    return false;
                }
                lineToChange.LineStations = line.LineStations;

                db.SaveChanges();
                return true;
            }
        }

        public bool Insert(Line line)
        {
            if (line.LineId == default)
            {
                return false;
            }
            if (line.Name.Equals(""))
            {
                return false;
            }
            if (line.Price == default)
            {
                return false;
            }
            using (var db = new VyDbContext())
            {
                db.Lines.Add(line);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                var line = db.Lines.Find(id);
                if (line == null)
                {
                    return false;
                }
                db.Lines.Remove(line);
                db.SaveChanges();
                return true;
            }
        }
    }
}