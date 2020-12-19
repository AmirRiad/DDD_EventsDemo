using Events.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class GoToHospital : IHandle<PersonGotInfectedEvent>
    {
        //public static void GotoHospital(PersonGotInfected _event) 
        //{
        //    // Go To Hospital
        //    Console.WriteLine(_event.person.Name + " is going to" + HospitalName);
        //}

        //public static Action<PersonGotInfected> Handle = GotoHospital;

        public static string HospitalName = "Ramsis Hospital";

        public void Handle(PersonGotInfectedEvent argument)
        {
            Console.WriteLine(argument.person.Name + " is going to" + HospitalName);
        }
    }
}
