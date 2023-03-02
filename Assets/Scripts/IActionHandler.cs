using UnityEngine;

namespace DefaultNamespace
{
    public interface IActionHandler
    {
        public void QueueAction(GameObject gameObject, Action action);
    }
}