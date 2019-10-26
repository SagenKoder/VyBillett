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
                // Finds the Station from the database
                // TODO: Test if this one work! The example wasn't clear
                var lineToChange = db.Lines.First(s => s.LineId == id);
                if (lineToChange == null)
                {
                    logdb.Error("{Repository} Edit: No lines with id=\"{-1}\"", repositoryName, id);
                    return false;
                }

                if (lineToChange.Name.Equals(""))
                {
                    logdb.Error("{Repository} Edit: No lines with name=\"{}\"", repositoryName, lineToChange.Name);
                    return false;
                }
                lineToChange.Name = line.Name;
                
                //if (lineToChange.Price == default)
                //{
                //    logdb.Error("{Repository} Edit: No lines with price=\"{-1}\"", repositoryName, lineToChange.Price);
                //    return false;
                //}
                //lineToChange.Price = line.Price;

                if (lineToChange.LineStations == null)
                {
                    logdb.Error("{Repository} Edit: No lines with lineStation=\"{null}\"", repositoryName, null);
                    return false;
                }
                lineToChange.LineStations = line.LineStations;

                logdb.Info("{Repository} Edit({null}): {0}", repositoryName, id, line.ToString());
                db.SaveChanges();
                return true;
            }
        }

        public Line Insert(Line line)
        {
            //if (line.LineId == default)
            //{
            //    logdb.Info("{Repository} Insert: {null}", repositoryName, line.ToString());
            //    return false;
            //}
            //if (line.Name.Equals(""))
            //{
            //    logdb.Error("{Repository} Insert: name=\"{null}\"", repositoryName, line.Name);
            //    return false;
            //}
            //if (line.Price == default)
            //{
            //    logdb.Error("{Repository} Insert: price=\"{null}\"", repositoryName, line.Price);
            //    return false;
            //}
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
    }
}