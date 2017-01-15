﻿using System;
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
        Ticket ReadTicket(int ticketNumber);
        void UpdateTicket(Ticket t);
        void DeleteTicket(int ticketNumber);

        IEnumerable<TicketResponse> ReadAllTicketResponses(int ticketNumber);
        TicketResponse CreateTicketResponse(TicketResponse tr);
    }
}
