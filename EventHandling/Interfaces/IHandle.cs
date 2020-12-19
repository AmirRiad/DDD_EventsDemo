using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Events
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T argument);
    }
}
