using api.events;
using UnityEngine;

namespace DefaultNamespace
{
    public class JumpEvent : GameEvent
    {
        public Player Player { get; set; }
        public int Height { get; set; }
    }
}