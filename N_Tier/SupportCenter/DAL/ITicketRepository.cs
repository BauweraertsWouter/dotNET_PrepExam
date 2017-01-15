using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;

namespace SC.DAL
{
    public interface ITicketRepository
    {
        Ticket CreateTicket(Ticket ticket);
        IEnumerable<Ticket> ReadTickets();

    }
}
