using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Structs
{
    public unsafe struct SDL_DropEvent
    {
        /// <summary>
        /// SDL_DROPFILE, SDL_DROPTEXT, SDL_DROPBEGIN, or SDL_DROPCOMPLETE.
        /// </summary>
        public SDL_EventType type;
        /// <summary>timestamp of the event.</summary>
        public uint timestamp;
        /// <summary>the file name, which should be freed with SDL_free(), is NULL on BEGIN/COMPLETE</summary>
        public byte* file;
        /// <summary>the window that was dropped on, if any</summary>
        public uint windowID;
    }
}