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

        private readonly IDepartureRepository _departureRepository;

        public DepartureBLL()
        {
            _departureRepository = new DepartureRepository();
        }
        public DepartureBLL(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }
        public int Count()
        {
            return _departureRepository.Count();
        }

        public List<Departure> Get()
        {
            return _departureRepository.Get();
        }

        public List<Departure> GetFromLineId(int lineId)
        {
            return _departureRepository.GetFromLineId(lineId);
        }

        public Departure Insert(Departure departure)
        {
            return _departureRepository.Insert(departure);

        }
        public Departure Get(int id)
        {
            return _departureRepository.GetFromId(id);
        }

        public void Delete(int id)
        {
            _departureRepository.Delete(id);
        }
    }
}
