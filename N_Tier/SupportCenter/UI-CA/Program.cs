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
                try
                {
                    ShowMenu();
                    keuze = DetectUserInput();
                    RedirectToMenuAction(keuze);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
                    actionTrigger = delegate () { ShowTicketDetails(); };
                    break;
                case 3:
                    actionTrigger = delegate () { ShowTicketResponsesOfTicket(); };
                    break;
                case 4:
                    actionTrigger = delegate () { CreateNewTicket(); };
                    break;
                case 5:
                    actionTrigger = delegate () { CreateAnswerToTicket(); };
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ONGELDIGE KEUZE. PROBEER OPNIEUW, KIES 0 OM AF TE SLUITEN");
                    return;
            }
            actionTrigger();
        }

        private static void CreateAnswerToTicket()
        {
            Console.Write("Ticketnummer: ");
            string str = Console.ReadLine();
            int ticket;
            if (!int.TryParse(str, out ticket))
                throw new ArgumentException("Ongeldig ticketnummer");
            Console.Write("Client answer (j/n)?");
            bool client = false;
            if (Console.ReadLine().ToLower() == "j")
                client = true;
            Console.Write("Antwoord: ");
            string answer = Console.ReadLine();
            mgr.AddTicketResponse(ticket, answer, client);
        }

        private static void ShowTicketResponsesOfTicket()
        {
            Console.Write("Ticketnummer: ");
            string str = Console.ReadLine();
            int ticket;
            if (!Int32.TryParse(str, out ticket))
                throw new ArgumentException("Ongeldig ticketnummer");
            if(mgr.GetTicketResponses(ticket).Count() == 0)
                Console.WriteLine("Geen antwoorden gevonden");
            else
                foreach(TicketResponse tr in mgr.GetTicketResponses(ticket))
                {
                    Console.WriteLine(tr.GetInfo());
                }
        }

        private static void ShowTicketDetails()
        {
            Console.Write("Ticketnummer: ");
            string str = Console.ReadLine();
            int choice;
            if (!Int32.TryParse(str, out choice))
                throw new ArgumentException("ONGELDIGE KEUZE!");
            Ticket t = mgr.GetTicket(choice);
            Console.WriteLine(t.GetDetails());
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
            Console.WriteLine("2) Toon details van een ticket");
            Console.WriteLine("3) Toon de antwoorden van een ticket");
            Console.WriteLine("4) Maak een nieuw ticket");
            Console.WriteLine("5) Geef een antwoord op een ticket");
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
