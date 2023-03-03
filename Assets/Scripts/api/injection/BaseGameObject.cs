using System;
using api.events;
using UnityEngine;

namespace api.injection
{
    public abstract class BaseGameObject : MonoBehaviour
    {
        private void Awake()
        {
            Injector.Inject(this);
            var eventInvoker = FindObjectOfType<EventInvoker>();
            eventInvoker.RegisterListeners(this);
            OnAwake();
        }
        
        /*
         * Call this instead of Awake()
         */
        protected virtual void OnAwake()
        {
        }
    }
}