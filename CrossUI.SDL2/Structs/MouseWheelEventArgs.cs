namespace CrossUI.SDL2.Structs
{
    public struct MouseWheelEventArgs
    {
        public MouseState State { get; }
        public float WheelDelta { get; }
        public MouseWheelEventArgs(MouseState mouseState, float wheelDelta)
        {
            State = mouseState;
            WheelDelta = wheelDelta;
        }
    }
}