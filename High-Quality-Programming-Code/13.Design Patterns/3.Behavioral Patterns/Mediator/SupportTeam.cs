using System;

namespace Mediator
{
    public class SupportTeam : ISupportTeam
    {
        public SupportTeam(string team, ITicketSystemMediator ticketSystem)
        {
            this.Team = team;
            this.TicketSystem = ticketSystem;
        }

        public string Team { get; private set; }

        public ITicketSystemMediator TicketSystem { get; private set; }

        public void SendResponseToMediator(string response)
        {
            this.TicketSystem.ReceiveResponseFromSupportTeam(response);
        }

        public void ReceiveTicketFromMediator(Ticket ticket)
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine(ticket);
            Console.WriteLine(new string('-', 10));
        }
    }
}
