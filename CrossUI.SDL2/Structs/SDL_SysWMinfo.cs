namespace CrossUI.SDL2.Structs
{
    public struct SDL_SysWMinfo
    {
        public SDL_version version;
        public SysWMType subsystem;
        public WindowInfo info;
    }
}