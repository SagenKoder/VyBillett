using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LineBLL : ILineBLL
    {
        LineRepository db = new LineRepository();
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        public List<Line> GetAllLines()
        {
            return db.Get();
        }
        public Line GetLineFromName(string name)
        {
            return db.Get(name);
        }
        public Line GetLineFromId(int id)
        {
            return db.Get(id);
        }
        public void DeleteLine(int id)
        {
            db.Delete(id);
        }
        public void EditLine(int id, Line line)
        {
            db.Edit(id, line);
        }
        public Line Insert(Line line)
        {
            logerror.Debug("Line name: " + line.Name);
            return db.Insert(line);
        }
        public int Count()
        {
            return db.Count();
        }
    }


}
