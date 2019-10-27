using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartureRepositoryStab : IDepartureRepository
    {

        public int Count()
        {
            return 10;
        }

        public List<Departure> Get()
        {
            ILineRepository lineRepository = new LineRepositoryStab();
            List<Departure> departures = new List<Departure>();
            for(int i = 1; i <= 10; i++)
            {
                var departure = new Departure();
                departure.DepartureId = i;
                departure.DateTime = DateTime.Now.AddHours(i);
                departure.Line = lineRepository.Get().First();
            }
            return departures;
        }

        public List<Departure> GetFromLineId(int lineId)
        {
            ILineRepository lineRepository = new LineRepositoryStab();
            List<Departure> departures = new List<Departure>();
            for (int i = 1; i <= 10; i++)
            {
                var departure = new Departure();
                departure.DepartureId = i;
                departure.DateTime = DateTime.Now.AddHours(i);
                departure.Line = lineRepository.Get(lineId);
            }
            return departures;
        }

        public Departure GetFromId(int id)
        {
            ILineRepository lineRepository = new LineRepositoryStab();
           
            var departure = new Departure();
            departure.DepartureId = id;
            departure.DateTime = DateTime.Now.AddHours(id);
            departure.Line = lineRepository.Get(id);

            return departure;
        }

        public Departure Insert(Departure departure)
        {
            departure.DepartureId = 5;
            return departure;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
