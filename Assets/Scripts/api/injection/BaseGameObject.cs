using System;
using UnityEngine;

namespace api.injection
{
    public abstract class BaseGameObject : MonoBehaviour
    {
        private void Awake()
        {
            Injector.Inject(this);
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