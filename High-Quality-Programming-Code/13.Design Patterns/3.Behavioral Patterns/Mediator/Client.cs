using System;

namespace Mediator
{
    public class Client : IClient
    {
        public Client(string name, ITicketSystemMediator ticketSystem)
        {
            this.Name = name;
            this.TicketSystem = ticketSystem;
        }

        public string Name { get; private set; }

        public ITicketSystemMediator TicketSystem { get; private set; }

        public void SendTicketToMediator(Ticket ticket)
        {
            this.TicketSystem.ReceiveTicketFromClient(ticket);
        }

        public void ReceiveResponseFromMediator(string response)
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine(response);
            Console.WriteLine(new string('-', 10));
        }
    }
}
