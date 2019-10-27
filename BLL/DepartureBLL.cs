using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class DepartureBLL : IDepartureBLL
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        private DepartureRepository departureRepository;

        public DepartureBLL()
        {
            departureRepository = new DepartureRepository();
        }


        public int Count()
        {
            return departureRepository.Count();
        }

        public List<Departure> Get()
        {
            return departureRepository.Get();
        }

        public List<Departure> GetFromLineId(int lineId)
        {
            return departureRepository.GetFromLineId(lineId);
        }

        public Departure Insert(Departure departure)
        {
            return departureRepository.Insert(departure);

        }

        public Departure Get(int id)
        {
            return departureRepository.GetFromId(id);
        }

        public void Delete(int id)
        {
            departureRepository.Delete(id);
        }
    }
}
