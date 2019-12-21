using System;

namespace CrossUI.SDL2.Structs
{
    public struct Win32WindowInfo
    {
        /// <summary>
        /// The Sdl2Window handle.
        /// </summary>
        public IntPtr Sdl2Window;
        /// <summary>
        /// The Sdl2Window device context.
        /// </summary>
        public IntPtr hdc;
        /// <summary>
        /// The instance handle.
        /// </summary>
        public IntPtr hinstance;
    }
}