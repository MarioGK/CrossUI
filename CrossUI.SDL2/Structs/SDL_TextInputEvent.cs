using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// Keyboard text input event structure (event.text.*)
    /// </summary>
    public unsafe struct SDL_TextInputEvent
    {
        public const int MaxTextSize = 32;

        /// <summary>
        /// SDL_TEXTINPUT.
        /// </summary>
        public SDL_EventType type;
        public uint timestamp;
        /// <summary>
        /// The Sdl2Window with keyboard focus, if any.
        /// </summary>
        public uint windowID;
        /// <summary>
        /// The input text.
        /// </summary>
        public fixed byte text[MaxTextSize];
    }
}