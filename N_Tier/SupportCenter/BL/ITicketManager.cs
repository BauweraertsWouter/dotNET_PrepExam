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
        Ticket GetTicket(int ticketNumber);
        Ticket AddTicket(int accountID, string question);
        Ticket AddTicket(int accountID, string device, string problem);
        void changeTicket(Ticket ticket);
        void RemoveTicket(int ticketNumber);

        IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber);
        TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse);
    }
}
