using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        TicketRepository ticketRepository;

        public TicketBLL()
        {
            ticketRepository = new TicketRepository();
        }

        public int Count()
        {
            return ticketRepository.Count();
        }
    }
}
