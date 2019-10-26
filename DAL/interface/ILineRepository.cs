using System.Collections.Generic;
using Model;

namespace DAL
{
    public interface ILineRepository
    {
        List<Line> Get();
        Line Get(int id);
        Line Get(string name);
        bool Edit(int id, Line line);
        Line Insert(Line line);
        bool Delete(int id);
    }
}