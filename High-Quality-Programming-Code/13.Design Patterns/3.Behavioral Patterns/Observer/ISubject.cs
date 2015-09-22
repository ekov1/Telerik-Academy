using System.Collections.Generic;

namespace Observer
{
    public interface ISubject
    {
        List<IObserver> Subscribers { get; }

        void AttachObserver(IObserver subscriber);

        void DetachObserver(IObserver subscriber);
    }
}
