using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.BL.Domain
{
    public class TicketResponse
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public bool IsClientResponse { get; set; }
        public string Text { get; set; }
        public Ticket Ticket { get; set; }
    }
}
