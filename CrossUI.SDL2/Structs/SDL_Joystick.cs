using System;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// A transparent wrapper over a pointer to a native SDL_Joystick.
    /// </summary>
    public struct SDL_Joystick
    {
        /// <summary>
        /// The native SDL_Joystick pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public SDL_Joystick(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(SDL_Joystick controller) => controller.NativePointer;
        public static implicit operator SDL_Joystick(IntPtr pointer) => new SDL_Joystick(pointer);
    }
}