using System;

namespace api.events
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EventListener : Attribute
    {
        private readonly EventPiority _piority;

        public EventPiority EventPiority => _piority;

        public EventListener(EventPiority piority = EventPiority.Medium)
        {
         _piority = piority;
        }
    }

    public enum EventPiority
    {
        Low, Medium, High, Monitor
    }
}