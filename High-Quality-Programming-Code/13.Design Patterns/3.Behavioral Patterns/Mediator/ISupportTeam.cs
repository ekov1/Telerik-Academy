namespace Mediator
{
    public interface ISupportTeam
    {
        string Team { get; }
        ITicketSystemMediator TicketSystem { get; }
        void SendResponseToMediator(string response);
        void ReceiveTicketFromMediator(Ticket ticket);
    }
}
