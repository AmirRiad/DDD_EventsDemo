using Events.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;

namespace Events
{
    public class DomainEvents
    {
        private static Dictionary<Type, List<Delegate>> events = new Dictionary<Type, List<Delegate>>();
        private static Dictionary<Type, List<object>> handles = new Dictionary<Type, List<object>>();

        public static void RegisterEvent<T>()
        {
            var type = typeof(T);
            if (!events.ContainsKey(type))
            {
                events.Add(type, new List<Delegate>());
                handles.Add(type, new List<object>());
            }
        }

        public static void Subscribe<T>(Action<T> action)
        {
            var type = typeof(T);

            #region Safety check
            if (!events.ContainsKey(type))
                events.Add(type, new List<Delegate>());
            #endregion

            //event handlers for this specific event
            var eventHandlers = events[type];
            eventHandlers.Add(action);
        }

        public static void Raise<T>(T argument) where T : IDomainEvent
        {
            var type = typeof(T);

            #region Safety check
            if (!events.ContainsKey(type))
            {
                events.Add(type, new List<Delegate>());
                handles.Add(type, new List<object>());
            }
            #endregion

            foreach (var handle in handles[type])
            {
                ((IHandle<T>)handle).Handle(argument);
            }


            //dynamically added
            var actions = events[type];

            foreach (var handler in actions)
            {
                handler.DynamicInvoke(argument);
            }
        }

        //should be replaced by IOC
        public static void SubscribeHandler<T>(IHandle<T> handle) where T : IDomainEvent
        {
            var type = typeof(T);

            #region Safety check
            if (!events.ContainsKey(type))
            {
                events.Add(type, new List<Delegate>());
                handles.Add(type, new List<object>());
            }
            #endregion

            //event handlers for this specific event
            var eventHandlers = handles[type];
            eventHandlers.Add(handle);
        }
    }
}
