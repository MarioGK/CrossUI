using System.Numerics;

namespace CrossUI.SDL2.Structs
{
    public struct MouseMoveEventArgs
    {
        public MouseState State { get; }
        public Vector2 MousePosition { get; }
        public MouseMoveEventArgs(MouseState mouseState, Vector2 mousePosition)
        {
            State = mouseState;
            MousePosition = mousePosition;
        }
    }
}