using Events.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class CallFriends : IHandle<PersonGotInfectedEvent>
    {
        //public static void CallMyFriends(PersonGotInfected _event)
        //{
        //    //Calling Friends
        //    foreach (var friend in _event.person.Friends)
        //    {
        //        Console.WriteLine("Calling - " + friend.Name);
        //    }
        //}
        //public static Action<PersonGotInfected> Handle = CallMyFriends;

        public void Handle(PersonGotInfectedEvent argument)
        {
            foreach (var friend in argument.person.Friends)
            {
                Console.WriteLine("Calling - " + friend.Name);
            }
        }
    }
}
