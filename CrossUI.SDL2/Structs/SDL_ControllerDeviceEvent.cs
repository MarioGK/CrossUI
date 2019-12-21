using System.Runtime.InteropServices;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    struct SDL_ControllerDeviceEvent
    {
        /// <summary>
        /// SDL_CONTROLLERDEVICEADDED, SDL_CONTROLLERDEVICEREMOVED, or SDL_CONTROLLERDEVICEREMAPPED.
        /// </summary>
        public uint type;
        /// <summary>
        /// In milliseconds, populated using SDL_GetTicks().
        /// </summary>
        public uint timestamp;
        /// <summary>
        /// The joystick device index for the ADDED event, instance id for the REMOVED or REMAPPED event.
        /// </summary>
        public int which;
    }
}