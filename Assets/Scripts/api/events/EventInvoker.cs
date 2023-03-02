using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace api.events
{
    public class EventInvoker : MonoBehaviour
    {
        private readonly Dictionary<Type, List<Action<object>>> _events = new();
        public Dictionary<Type, List<Action<object>>> RegisteredEvents => _events;

        public bool InvokeEvent<T>(T event_) where T : GameEvent
        {
            if (_events.TryGetValue(event_.GetType(), out var listeners))
            {
                foreach(var listener in listeners)
                {
                    listener.Invoke(event_);
                }
            }
            return event_.Cancel;
        }

        public void OnEvent<T>(Action<T> onEvent) where T : GameEvent
        {
            var type = typeof(T);

            if (!_events.ContainsKey(type))
            {
                _events.Add(type, new List<Action<object>>());
            }
            _events[type].Add( new Action<object>(o => onEvent((T)o)));
        }
    }
}