using Events.Events;
using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //DomainEvents.RegisterEvent("isInfected");
            //DomainEvents.Subscribe("isInfected", GoToHospital.Handle);
            //DomainEvents.Subscribe("isInfected", CallFriends.Handle);

            DomainEvents.RegisterEvent<PersonGotInfectedEvent>();
            //DomainEvents.Subscribe(GoToHospital.Handle);
            //DomainEvents.Subscribe(CallFriends.Handle);

            ///IOC Container
            ///should be removed when we use IOC Container
            DomainEvents.SubscribeHandler(new GoToHospital());
            DomainEvents.SubscribeHandler(new CallFriends());

            Person Amir = new Person { Name = "Amir" };
            Person Eslam = new Person { Name = "Eslam" };
            Person Abdelwahab = new Person { Name = "Abdelwahab" };

            Amir.AddFriend(Eslam);
            Amir.AddFriend(Abdelwahab);

            Amir.GotInfected();

            Console.ReadLine();
        }
    }
}
