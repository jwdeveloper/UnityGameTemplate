using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                foreach (var listener in listeners)
                {
                    listener.Invoke(event_);
                }
            }

            return event_.Cancel;
        }

        public void OnEvent<T>(Action<T> onEvent) where T : GameEvent
        {
            OnEvent(typeof(T), o => onEvent((T)o));
        }

        public void OnEvent(Type type, Action<object> onEvent)
        {
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, new List<Action<object>>());
            }
            _events[type].Add(onEvent);
        }

        public void RegisterListeners(MonoBehaviour instance)
        {
            var type = instance.GetType();
            foreach (var method in type.GetMethods())
            {
                if (!method.HasAttribute(typeof(EventListener)))
                {
                    continue;
                }
                var params_ = method.GetParameters();
                if (params_.Length != 1)
                {
                    throw new ArgumentException("There should be only parameter in Listener method");
                }

                var param = params_[0];
                var paramType = param.GetType();
                OnEvent(paramType, o =>
                {
                    method.Invoke(instance, new[] { o });
                });
            }
        }
    }
}