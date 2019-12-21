using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_Event
    {
        [FieldOffset(0)]
        public SDL_EventType type;
        [FieldOffset(4)]
        public uint timestamp;
        [FieldOffset(8)]
        public uint windowID;
        [FieldOffset(0)]
        private Bytex56 __padding;
        private unsafe struct Bytex56 { private fixed byte bytes[56]; }
    }
}