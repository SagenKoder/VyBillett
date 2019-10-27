using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL : ITicketBLL
    {
        private readonly NLog.Logger logdb = NLog.LogManager.GetLogger("database");
        private readonly NLog.Logger logerror = NLog.LogManager.GetLogger("error");

        private readonly ITicketRepository _ticketRepository;

        public TicketBLL()
        {
            _ticketRepository = new TicketRepository();
        }

        public TicketBLL(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public int Count()
        {
            return _ticketRepository.Count();
        }
    }
}
