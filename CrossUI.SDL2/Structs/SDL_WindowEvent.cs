using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowEvent
    {
        /// <summary>
        /// SDL_WINDOWEVENT
        /// </summary>
        public SDL_EventType type;
        public uint timestamp;
        /// <summary>
        /// The associated Sdl2Window
        /// </summary>
        public uint windowID;
        /// <summary>
        /// SDL_WindowEventID
        /// </summary>
        public SDL_WindowEventID @event;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        /// <summary>
        /// event dependent data
        /// </summary>
        public int data1;
        /// <summary>
        /// event dependent data
        /// </summary>
        public int data2;
    }
}