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

        internal static string GetDetails(this Ticket t)
        {
            return string.Format("{0,-15}: {1}\n{2,-15}: {3}\n{4,-15}: {5}\n{6,-15}: {7}\n{8,-15}: {9}",
                "Ticket ",
                t.TicketNumber,
                "Gebruiker ",
                t.AccountId,
                "Datum ",
                t.DateOpened,
                "Status ",
                t.State,
                "Vraag/Probleem ",
                t.Text);
        }

        internal static string GetInfo(this TicketResponse tr)
        {
            return string.Format("{0:dd/MM/yyyy} {1} {2}",
                tr.Date,
                tr.Text,
                tr.IsClientResponse ? "(client)" : "");
        }
    }
}
