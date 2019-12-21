using System;

namespace CrossUI.SDL2.Structs
{
    /// <summary>
    /// A transparent wrapper over a pointer to a native SDL_GameController.
    /// </summary>
    public struct SDL_GameController
    {
        /// <summary>
        /// The native SDL_GameController pointer.
        /// </summary>
        public readonly IntPtr NativePointer;

        public SDL_GameController(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static implicit operator IntPtr(SDL_GameController controller) => controller.NativePointer;
        public static implicit operator SDL_GameController(IntPtr pointer) => new SDL_GameController(pointer);
    }
}
