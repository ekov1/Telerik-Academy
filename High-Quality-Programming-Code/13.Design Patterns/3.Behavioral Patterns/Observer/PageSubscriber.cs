using System;

namespace Observer
{
    public class PageSubscriber : IObserver
    {
        public PageSubscriber(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Notify(ISubject subject)
        {
            var s = (FacebookPage)subject;
            Console.WriteLine(this.Name + " has been notified of ~~" + s.PageName + "~~\'s update on their page: " + s.Post);
        }
    }
}
