using UnityEngine;

namespace api.events
{
    public abstract class GameEvent
    {
        protected bool IsCanceld;

        public bool Cancel
        {
            get { return IsCanceld; }
            set { IsCanceld = value; }
        }
        
    }
}