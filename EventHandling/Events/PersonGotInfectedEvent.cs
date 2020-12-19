using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Events
{
    public class PersonGotInfectedEvent : IDomainEvent
    {
        public Person person { get; set; }
    }
}
