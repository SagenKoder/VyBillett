using Model;
using System.Collections.Generic;

namespace BLL
{
    public interface IDepartureBLL
    {
        int Count();
        List<Departure> Get();
        List<Departure> GetFromLineId(int lineId);
        Departure Insert(Departure departure);
        Departure Get(int id);
        void Delete(int id);
    }
}
