namespace Mediator
{
    public interface ITicketSystemMediator
    {
        IClient Client { get; }
        ISupportTeam SupportTeam { get; }

        void ReceiveTicketFromClient(Ticket ticket);
        void SendTicketToSupportTeam(Ticket ticket);
        void ReceiveResponseFromSupportTeam(string response);
        void SendResponseToClient(string response);
    }
}
