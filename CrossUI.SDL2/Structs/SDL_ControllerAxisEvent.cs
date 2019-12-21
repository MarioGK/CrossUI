using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerAxisEvent
    {
        /// <summary>
        /// SDL_CONTROLLERAXISMOTION.
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
        /// The controller axis.
        /// </summary>
        public SDL_GameControllerAxis axis;
        private byte padding1;
        private byte padding2;
        private byte padding3;
        /// <summary>
        /// The axis value (range: -32768 to 32767)
        /// </summary>
        public short value;
        private ushort padding4;
    }
}