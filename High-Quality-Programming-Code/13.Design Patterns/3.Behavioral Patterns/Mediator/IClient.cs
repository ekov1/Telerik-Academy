namespace Mediator
{
    public interface IClient
    {
        string Name { get; }
        ITicketSystemMediator TicketSystem { get; }
        void SendTicketToMediator(Ticket ticket);
        void ReceiveResponseFromMediator(string response);
    }
}
