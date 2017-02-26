using System;
using System.Collections.Generic;

namespace PPRWBYTrn.Hack.Managers
{
    enum Events
    {
        OnUpdate,
        OnGui
    }

    class EventMgr
    {
        private static Dictionary<Events, List<Action>> EventFuncs = new Dictionary<Events, List<Action>>();

        public static bool shouldContinue = true;

        public static void Reset()
        {
            EventFuncs.Clear();
            foreach (Events Event in Enum.GetValues(typeof(Events)))
            {
                EventFuncs.Add(Event, new List<Action>());
            }
        }

        public static void RegisterFunc(Events eventname, Action funky)
        {
            EventFuncs[eventname].Add(funky);
        }

        public static void DeleteFunc(Events eventname, Action funky)
        {
            EventFuncs[eventname].Remove(funky);
        }

        public static void InvokeEvent(Events eventName)
        {
            foreach(Action funky in EventFuncs[eventName])
            {
                funky();
                if (!shouldContinue)
                    break;
            }

            shouldContinue = true;
        }
    }
}
