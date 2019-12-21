using System;

namespace CrossUI.SDL2.Enumerations
{
    [Flags]
    public enum SDLRendererFlags : uint
    {
        SDLRendererSoftware =		0x00000001,
        SDLRendererAccelerated =	0x00000002,
        SDLRendererPresentVsync =	0x00000004,
        SDLRendererTargetTexture =	0x00000008
    }
}