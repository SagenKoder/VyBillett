using Model;
using System.Collections.Generic;

namespace BLL
{
    public interface ILineBLL
    {
        List<Line> GetAllLines();
        Line GetLineFromName(string name);
        Line GetLineFromId(int id);
        void DeleteLine(int id);
        void EditLine(int id, Line line);
        Line Insert(Line line);
        int Count();
    }
}
