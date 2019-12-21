namespace CrossUI.SDL2.Enumerations
{
    public enum SDL_FullscreenMode : uint
    {
        Windowed = 0,
        Fullscreen = 0x00000001,
        FullScreenDesktop = (Fullscreen | 0x00001000),
    }
}