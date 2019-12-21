using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// Mouse wheel event structure (event.wheel.*).
    /// </summary>
    public struct SDL_MouseWheelEvent
    {
        /// <summary>
        /// SDL_MOUSEWHEEL.
        /// </summary>
        public SDL_EventType type;
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with mouse focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The mouse instance id, or SDL_TOUCH_MOUSEID.
        /// </summary>
        public uint which;
        /// <summary>
        /// The amount scrolled horizontally, positive to the right and negative to the left.
        /// </summary>
        public int x;
        /// <summary>
        /// The amount scrolled vertically, positive away from the user and negative toward the user.
        /// </summary>
        public int y;
        /// <summary>
        /// Set to one of the SDL_MOUSEWHEEL_* defines. When FLIPPED the values in X and Y will be opposite. Multiply by -1 to change them back.
        /// </summary>
        public uint direction;
    }
}