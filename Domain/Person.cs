using Events.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Person
    {
        public string Name { get; set; }
        public bool isInfected { get; set; }
        public List<Person> Friends { get; set; } = new List<Person>();

        public void AddFriend(Person friend)
        {
            Friends.Add(friend);
        }


        public void GotInfected()
        {
            // Logic
            isInfected = true;
            Console.WriteLine(Name + ": Cough Cough");

            //Raise Event
            DomainEvents.Raise(new PersonGotInfectedEvent() { person = this });
        }
    }
}
