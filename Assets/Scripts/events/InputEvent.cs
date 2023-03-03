using api.events;

namespace events
{
    public class InputEvent : GameEvent
    {
        public Direction Direction { get; set; }
    }


    public enum Direction
    {
        None, Left, Right, Up, Down
    }
}