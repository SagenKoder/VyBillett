using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStationRepository
    {
        List<Station> Get();
        Station Get(int id);
        Station Get(string name);
        bool Edit(int id, Station station);
        Station Insert(Station station);
        bool Delete(int id);
    }
}
