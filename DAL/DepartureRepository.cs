using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartureRepository
    {

        public int Count()
        {
            using (var db = new VyDbContext())
            {
                return db.Departures.Count();
            }
        }
    }
}
