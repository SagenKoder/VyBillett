using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStationLogic
    {
        List<Station> GetAllStations();

        Station GetStationFromName(string name);

        Station GetStationFromId(int id);

        void DeleteStation(int id);

        void EditStation(int id, Station station);

        Station Insert(Station station);
    }
}
