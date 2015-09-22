using System;
using System.Collections.Generic;

namespace Observer
{
    public class FacebookPage : ISubject
    {
        public FacebookPage(string name)
        {
            this.PageName = name;
            this.Subscribers = new List<IObserver>();
        }

        public List<IObserver> Subscribers { get; private set; }

        public string PageName { get; private set; }
        public string Post { get; private set; }

        public void MakePost(string content)
        {
            this.Post = content;

            NotifyObservers();
        }

        public void AttachObserver(IObserver subscriber)
        {
            if (!this.Subscribers.Contains(subscriber))
            {
                this.Subscribers.Add(subscriber);
            }
        }

        public void DetachObserver(IObserver subscriber)
        {
            if (this.Subscribers.Contains(subscriber))
            {
                this.Subscribers.Add(subscriber);
            }
            else
            {
                Console.WriteLine("No such subscriber to this page.");
            }
        }

        public void NotifyObservers()
        {
            foreach (var subscriber in this.Subscribers)
            {
                subscriber.Notify(this);
            }
        }
    }
}
