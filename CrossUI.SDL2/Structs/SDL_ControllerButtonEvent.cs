using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerButtonEvent
    {
        /// <summary>
        /// SDL_CONTROLLERBUTTONDOWN or SDL_CONTROLLERBUTTONUP.
        /// </summary>
        public uint type;
        /// <summary>
        /// In milliseconds, populated using SDL_GetTicks().
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The joystick instance id.
        /// </summary>
        public int which;
        /// <summary>
        /// The controller button
        /// </summary>
        public SDL_GameControllerButton button;
        /// <summary>
        /// SDL_PRESSED or SDL_RELEASED
        /// </summary>
        public byte state;
        private byte padding1;
        private byte padding2;
    }
}