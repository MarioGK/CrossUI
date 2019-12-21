using System;

namespace CrossUI.SDL2.Structs
{
    public struct WaylandWindowInfo
    {
        public IntPtr display;
        public IntPtr surface;
        public IntPtr shellSurface;
    }
}