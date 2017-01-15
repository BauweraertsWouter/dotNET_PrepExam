using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UI.CA.Extensions
{
    static class ExtensionMethods
    {
        internal static string GetInfo(this Ticket t)
        {
            return string.Format("[{0}] {1} ({2} antwoorden)",
                t.TicketNumber,
                t.Text,
                t.Responses == null ? 0 : t.Responses.Count);
        }
    }
}
