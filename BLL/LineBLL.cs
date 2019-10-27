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
        private readonly ILineRepository _lineRepository;
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        public LineBLL()
        {
            _lineRepository = new LineRepository();
        }

        public LineBLL(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public List<Line> GetAllLines()
        {
            return _lineRepository.Get();
        }
        public Line GetLineFromName(string name)
        {
            return _lineRepository.Get(name);
        }
        public Line GetLineFromId(int id)
        {
            return _lineRepository.Get(id);
        }
        public void DeleteLine(int id)
        {
            _lineRepository.Delete(id);
        }
        public void EditLine(int id, Line line)
        {
            _lineRepository.Edit(id, line);
        }
        public Line Insert(Line line)
        {
            logerror.Debug("Line name: " + line.Name);
            return _lineRepository.Insert(line);
        }
        public int Count()
        {
            return _lineRepository.Count();
        }
    }


}
