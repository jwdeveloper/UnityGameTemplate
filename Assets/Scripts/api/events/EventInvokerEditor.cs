using UnityEditor;
using UnityEngine;

namespace api.events
{
    
    [CustomEditor(typeof(EventInvoker))]
    public class EventInvokerEditor : Editor
    {
        public override void OnInspectorGUI () 
        {
            base.OnInspectorGUI();

            
            EventInvoker invoker = (EventInvoker)target;
            var events = invoker.RegisteredEvents;
            foreach(var eventType in events.Keys)
            {
                GUILayout.Button($"{eventType.Name} listeners {events[eventType].Count}");
            }
        }
    }
}