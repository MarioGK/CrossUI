using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Events
{
    public struct MouseEvent
    {
        public MouseButton MouseButton { get; }
        public bool Down { get; }

        public MouseEvent(MouseButton button, bool down)
        {
            MouseButton = button;
            Down = down;
        }
    }

    
}