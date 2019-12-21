using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Keysym
    {
        /// <summary>
        /// SDL physical key code.
        /// </summary>
        public SDL_Scancode scancode;
        /// <summary>
        /// SDL virtual key code.
        /// </summary>
        public SDL_Keycode sym;
        /// <summary>
        /// current key modifiers.
        /// </summary>
        public SDL_Keymod mod;
        private uint __unused;
    }
}