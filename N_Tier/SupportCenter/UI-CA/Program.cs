using SC.BL;
using SC.BL.Domain;
using SC.UI.CA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UI.CA
{
    class Program
    {
        private static ITicketManager mgr = new TicketManager();
        private static bool exit = false;
        

        static void Main(string[] args)
        {
            int? keuze;
            do
            {
                ShowMenu();
                keuze = DetectUserInput();
                RedirectToMenuAction(keuze);
                WaitForNewLineAndClearConsole();
            } while (!exit);
        }

        private static void WaitForNewLineAndClearConsole()
        {
            if (!exit)
            {
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void RedirectToMenuAction(int? keuze)
        {
            Action actionTrigger;
            switch (keuze)
            {
                case 0:
                    exit = true;
                    return;
                case 1:
                    actionTrigger = delegate () { ShowAllTickets(); };
                    break;
                case 2:
                    actionTrigger = delegate () { CreateNewTicket(); };
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ONGELDIGE KEUZE. PROBEER OPNIEUW, KIES 0 OM AF TE SLUITEN");
                    return;
            }
            actionTrigger();
        }

        private static void CreateNewTicket()
        {
            string device = "";
            Console.Write("Is het een hardwareprobleem (j/n)? ");
            bool isHardwareProbleem = (Console.ReadLine().ToLower() == "j");
            if (isHardwareProbleem)
            {
                Console.Write("Naam van het toestel: ");
                device = Console.ReadLine();
            }

            Console.Write("Gebruikersnummer: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Probleem: ");
            string problem = Console.ReadLine();

            if (!isHardwareProbleem)
                mgr.AddTicket(accountNumber, problem);
            else
                mgr.AddTicket(accountNumber, device: device, problem: problem);
        }

        private static int? DetectUserInput()
        {
            string strKeuze = Console.ReadLine();
            int keuze;
            if (Int32.TryParse(strKeuze, out keuze))
                return keuze;
            else return null;
        }

        private static void ShowMenu()
        {
            string title = "=== HELPDESK - SUPPORT CENTER ===";
            string line = "";
            for(int i=0; i<title.Length; i++)
            {
                line += "=";
            }

            Console.WriteLine(line);
            Console.WriteLine(title);
            Console.WriteLine(line);
            Console.WriteLine("1) Toon alle tickets");
            Console.WriteLine("2) Maak een nieuw ticket");
            Console.WriteLine("0) Afsluiten");
            Console.Write("Keuze: ");
        }

        private static void ShowAllTickets()
        {
            IEnumerable<Ticket> tickets = mgr.GetTickets();
            foreach(Ticket t in tickets)
            {
                Console.WriteLine(t.GetInfo());
            }
        }
    }
}
