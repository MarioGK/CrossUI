using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// Mouse button event structure (event.button.*)
    /// </summary>
    public struct SDL_MouseButtonEvent
    {
        /// <summary>
        /// SDL_MOUSEBUTTONDOWN or ::SDL_MOUSEBUTTONUP.
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
        /// The mouse button index.
        /// </summary>
        public SDL_MouseButton button;
        /// <summary>
        /// Pressed (1) or Released (0).
        /// </summary>
        public byte state;
        /// <summary>
        /// 1 for single-click, 2 for double-click, etc.
        /// </summary>
        public byte clicks;
        public byte padding1;
        /// <summary>
        /// X coordinate, relative to Sdl2Window.
        /// </summary>
        public int x;
        /// <summary>
        /// Y coordinate, relative to Sdl2Window
        /// </summary>
        public int y;
    }
}