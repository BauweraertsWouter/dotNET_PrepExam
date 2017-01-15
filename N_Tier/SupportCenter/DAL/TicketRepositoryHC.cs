using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;

namespace SC.DAL
{
    public class TicketRepositoryHC : ITicketRepository
    {
        private List<Ticket> tickets;
        private List<TicketResponse> responses;

        public TicketRepositoryHC()
        {
            tickets = new List<Ticket>();
            responses = new List<TicketResponse>();
            Seed();
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            ticket.TicketNumber = tickets.Count() + 1;
            tickets.Add(ticket);
            return ticket;
        }

        public IEnumerable<Ticket> ReadTickets()
        {
            return tickets;
        }

        private void Seed()
        {
            Ticket t1 = new Ticket()
            {
                Text = "Ik kan mij niet aanmelden op de webmail",
                AccountId = 1,
                DateOpened = new DateTime(2012, 9, 9, 13, 5, 59),
                State = TicketState.Closed,
                Responses = new List<TicketResponse>(),
            };
            t1.Responses.Add(new TicketResponse()
            {
                Date = new DateTime(2012, 9, 9, 13, 24, 48),
                Text = "Account is geblokkeerd",
                Id = 1,
                IsClientResponse = false,
                Ticket = t1
            });
            t1.Responses.Add(new TicketResponse()
            {
                IsClientResponse = false,
                Id = 2,
                Ticket = t1,
                Text = "Account terug in orde en nieuw paswoord ingesteld",
                Date = new DateTime(2012, 9, 9, 13, 29, 11)
            });
            t1.Responses.Add(new TicketResponse()
            {
                Date = new DateTime(2012, 9, 10, 7, 22, 36),
                Text = "Aanmelden gelukt en paswoord gewijzigd",
                Ticket = t1,
                Id = 3,
                IsClientResponse = true
            });

            Ticket t2 = new Ticket()
            {
                TicketNumber = 2,
                AccountId = 1,
                DateOpened = new DateTime(2012, 11, 5, 9, 45, 13),
                Responses = new List<TicketResponse>(),
                State = TicketState.Answered,
                Text = "Geen internetverbinding"
            };
            t2.Responses.Add(new TicketResponse()
            {
                Id = 4,
                Date = new DateTime(2012, 11, 5, 11, 25, 42),
                IsClientResponse = false,
                Ticket = t2,
                Text = "Controleer of de kabel goed is aangesloten"
            });

            Ticket ht1 = new HardwareTicket()
            {
                AccountId = 1,
                TicketNumber = 3,
                Text = "Blue screen!",
                DateOpened = new DateTime(2012, 12, 14, 19, 5, 2),
                DeviceName = "PC-123456",
                Responses = new List<TicketResponse>(),
                State = TicketState.Open
            };

            tickets.Add(t1);
            tickets.Add(t2);
            tickets.Add(ht1);

            foreach(TicketResponse tr in t1.Responses)
            {
                responses.Add(tr);
            }

            foreach(TicketResponse tr in t2.Responses)
            {
                responses.Add(tr);
            }
        }

        public Ticket ReadTicket(int ticketNumber)
        {
            return tickets.SingleOrDefault<Ticket>(t => t.TicketNumber == ticketNumber);
        }

        public void UpdateTicket(Ticket t)
        {
            //Everything stays in memory. Updates don't need to be persisted
        }

        public void DeleteTicket(int ticketNumber)
        {
            tickets.Remove(tickets.SingleOrDefault<Ticket>(t => t.TicketNumber == ticketNumber));
            responses.RemoveAll(r => r.Ticket.TicketNumber == ticketNumber);
        }

        public IEnumerable<TicketResponse> ReadAllTicketResponsesOfTicket(int ticketNumber)
        {
            return ReadTicket(ticketNumber).Responses;
        }

        public TicketResponse CreateTicketResponse(TicketResponse tr)
        {
            tr.Id = responses.Count() + 1;
            int ticket = tr.Ticket.TicketNumber;
            if (ReadTicket(ticket).Responses == null)
                ReadTicket(ticket).Responses = new List<TicketResponse>();
            ReadTicket(ticket).Responses.Add(tr);
            responses.Add(tr);
            return tr;
        }
    }
}
