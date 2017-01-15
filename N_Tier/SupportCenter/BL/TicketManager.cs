using SC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;

namespace SC.BL
{
    public class TicketManager : ITicketManager
    {
        private ITicketRepository repo;

        public TicketManager()
        {
            repo = new TicketRepositoryHC();
        }

        public Ticket AddTicket(int accountID, string question)
        {
            Ticket t = new Ticket()
            {
                AccountId = accountID,
                Text = question,
                DateOpened = DateTime.Now,
                State = TicketState.Open
            };

            return this.AddTicket(t);
        }

        private Ticket AddTicket(Ticket t)
        {
            return repo.CreateTicket(t);
        }

        public Ticket AddTicket(int accountID, string device, string problem)
        {
            Ticket t = new HardwareTicket()
            {
                AccountId = accountID,
                DateOpened = DateTime.Now,
                DeviceName = device,
                State = TicketState.Open,
                Text = problem
            };

            return this.AddTicket(t);
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return repo.ReadTickets();
        }

        public Ticket GetTicket(int ticketNumber)
        {
            return repo.ReadTicket(ticketNumber);
        }

        public void changeTicket(Ticket ticket)
        {
            repo.UpdateTicket(ticket);
        }

        public void RemoveTicket(int ticketNumber)
        {
            repo.DeleteTicket(ticketNumber);
        }

        public IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber)
        {
            return repo.ReadAllTicketResponses(ticketNumber);
        }

        public TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse)
        {
            TicketResponse tr = new TicketResponse()
            {
                Date = DateTime.Now,
                Text = response,
                IsClientResponse = isClientResponse,
                Ticket = GetTicket(ticketNumber)
            };

            return repo.CreateTicketResponse(tr);
        }
    }
}
