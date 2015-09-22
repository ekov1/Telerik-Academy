using System;

namespace Mediator
{
    public class TicketSystemMediator : ITicketSystemMediator
    {
        public IClient Client { get; set; }

        public ISupportTeam SupportTeam { get; set; }

        public void ReceiveTicketFromClient(Ticket ticket)
        {
            this.SendTicketToSupportTeam(ticket);
        }

        public void SendTicketToSupportTeam(Ticket ticket)
        {
            Console.WriteLine("Ticket from client {0} ---> To Mediator ---> To {1} Support team:", this.Client.Name, this.SupportTeam.Team);
            this.SupportTeam.ReceiveTicketFromMediator(ticket);
        }

        public void ReceiveResponseFromSupportTeam(string response)
        {
            this.SendResponseToClient(response);
        }

        public void SendResponseToClient(string response)
        {
            Console.WriteLine("Response from {0} Support Team ---> To Mediator ---> To client {1}:", this.SupportTeam.Team, this.Client.Name);
            this.Client.ReceiveResponseFromMediator(response);
        }
    }
}
