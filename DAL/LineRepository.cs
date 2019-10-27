using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class LineRepository : ILineRepository
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");
        private readonly string repositoryName = "StationsRepository";

        public List<Line> Get()
        {
            using (var db = new VyDbContext())
            {
                var lines = db.Lines.ToList();
                logdb.Info("{Repository} Get(): {0} lines", repositoryName, lines.Count);
                foreach (var station in lines)
                {
                    logdb.Info("\tAccessed: {0}", station.ToString());
                }

                return lines;
            }
        }

        public Line Get(int id)
        {
            using (var db = new VyDbContext())
            {
                var line = db.Lines.Find(id);;
                if (line != null)
                {
                    logdb.Info("{Repository} Get({-1}): {0}", repositoryName, id, line.ToString());
                    return line;
                }

                return null;
            }
        }

        public Line Get(string name)
        {
            using (var db = new VyDbContext())
            {
                try
                {
                    var line = db.Lines.FirstOrDefault(l => l.Name.Equals(name));
                    logdb.Info("{Repository} Get({null}): {0}", repositoryName, name, line.ToString());
                    return line;
                }
                catch (Exception e)
                {
                    logdb.Error("{Repository} Get({null})", repositoryName, name);
                    return null;
                }
            }
        }

        public bool Edit(int id, Line line)
        {
            using (var db = new VyDbContext())
            {
                var lineToChange = db.Lines.First(s => s.LineId == id);

                lineToChange.Name = line.Name;
                
                logdb.Info("{Repository} Edit({null}): {0}", repositoryName, id, line.ToString());
                db.SaveChanges();
                return true;
            }
        }

        public Line Insert(Line line)
        {
            using (var db = new VyDbContext())
            {
                var inserted = db.Lines.Add(line);
                db.SaveChanges();
                logdb.Info("{Repository} Insert: {0}", repositoryName, line.ToString());
                return inserted;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new VyDbContext())
            {
                var line = db.Lines.Find(id);
                if (line == null)
                {
                    logdb.Error("{Repository} Delete({null})", repositoryName, id);
                    return false;
                }
                
                db.LineStations.RemoveRange(db.LineStations.Where(x => x.Line.LineId == id));
                db.Lines.Remove(line);
                db.SaveChanges();
                logdb.Info("{Repository} Delete({null})", repositoryName, id);
                return true;
            }
        }

        public int Count()
        {
            using (var db = new VyDbContext())
            {
                return db.Lines.Count();
            }
        }
    }
}