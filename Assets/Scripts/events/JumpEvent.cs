using api.events;

namespace events
{
    public class JumpEvent : GameEvent
    {
        public Player Player { get; set; }
        public int Height { get; set; }
    }
}