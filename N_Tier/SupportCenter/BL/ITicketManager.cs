using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.BL
{
    public interface ITicketManager
    {
        IEnumerable<Ticket> GetTickets();
        Ticket AddTicket(int accountID, string question);
        Ticket AddTicket(int accountID, string device, string problem);
    }
}
