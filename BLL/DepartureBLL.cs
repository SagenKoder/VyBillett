using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class DepartureBLL
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
    }
}
