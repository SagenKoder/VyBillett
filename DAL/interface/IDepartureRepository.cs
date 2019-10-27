using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDepartureRepository
    {
        int Count();
        List<Departure> Get();
        List<Departure> GetFromLineId(int lineId);
        Departure GetFromId(int id);
        Departure Insert(Departure departure);
        bool Delete(int id);
    }
}
