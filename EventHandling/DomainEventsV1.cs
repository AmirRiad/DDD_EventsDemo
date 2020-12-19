//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Tracing;
//using System.Text;

//namespace Events
//{
//    public class DomainEvents
//    {
//        private static Dictionary<string, List<Delegate>> events = new Dictionary<string, List<Delegate>>();

//        public static void RegisterEvent(string eventName)
//        {
//            if (!events.ContainsKey(eventName))
//                events.Add(eventName, new List<Delegate>());
//        }

//        public static void Subscribe<T>(string eventName, Action<T> action)
//        {
//            #region Safety check
//            if (!events.ContainsKey(eventName))
//                events.Add(eventName, new List<Delegate>());
//            #endregion

//            //event handlers for this specific event
//            var eventHandlers = events[eventName];
//            eventHandlers.Add(action);
//        }

//        public static void Raise<T>(string eventName, T argument)
//        {
//            #region Safety check
//            if (!events.ContainsKey(eventName))
//                events.Add(eventName, new List<Delegate>());
//            #endregion

//            var handlers = events[eventName];

//            foreach (var handler in handlers)
//            {
//                handler.DynamicInvoke(argument);
//            }
//        }
//    }
//}
