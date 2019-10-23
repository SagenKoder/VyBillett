using System.Collections.Generic;
using Model;

namespace DAL
{
    public interface ILineStationRepository
    {
        List<LineStation> Get();
        LineStation Get(int id);
        LineStation Get(string name);
        bool Edit(int id, LineStation lineStation);
        bool Insert(LineStation lineStation); 
        bool Delete(int id);
    }
}