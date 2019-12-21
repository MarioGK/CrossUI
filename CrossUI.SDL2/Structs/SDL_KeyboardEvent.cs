using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// Keyboard button event structure (event.key.*).
    /// </summary>
    public struct SDL_KeyboardEvent
    {
        /// <summary>
        /// SDL_KEYDOWN or SDL_KEYUP
        /// </summary>
        public SDL_EventType type;
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with keyboard focus, if any
        /// </summary>
        public uint windowID;
        /// <summary>
        /// Pressed (1) or Released (0).
        /// </summary>
        public byte state;
        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte repeat;
        public byte padding2;
        public byte padding3;
        /// <summary>
        /// The key that was pressed or released
        /// </summary>
        public SDL_Keysym keysym;
    }
}