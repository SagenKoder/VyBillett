using System.Collections.Generic;
using Model;

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
