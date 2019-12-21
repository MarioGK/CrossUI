using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// Mouse motion event structure (event.motion.*)
    /// </summary>
    public struct SDL_MouseMotionEvent
    {
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
        /// The current button state.
        /// </summary>
        public ButtonState state;
        /// <summary>
        /// X coordinate, relative to Sdl2Window.
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate, relative to Sdl2Window.
        /// </summary>
        public int y;
        /// <summary>
        /// The relative motion in the X direction.
        /// </summary>
        public int xrel;
        /// <summary>
        /// The relative motion in the Y direction.
        /// </summary>
        public int yrel;
    }
}