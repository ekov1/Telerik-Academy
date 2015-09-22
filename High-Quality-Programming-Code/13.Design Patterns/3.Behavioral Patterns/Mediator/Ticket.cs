using System;

namespace Mediator
{
    public class Ticket
    {
        public Ticket(string title, string body)
        {
            this.Title = title;
            this.Body = body;
        }

        public string Body { get; private set; }

        public string Title { get; private set; }

        public override string ToString()
        {
            return String.Format("'{0}':\n\t{1}", this.Title, this.Body);
        }
    }
}
