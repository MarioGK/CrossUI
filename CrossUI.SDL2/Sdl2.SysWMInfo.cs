using System.Runtime.InteropServices;
using CrossUI.SDL2.Objects;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowWMInfo_t(SDL_Window Sdl2Window, SDL_SysWMinfo* info);
        private static readonly SDL_GetWindowWMInfo_t s_getWindowWMInfo = LoadFunction<SDL_GetWindowWMInfo_t>("SDL_GetWindowWMInfo");
        public static int SDL_GetWMWindowInfo(SDL_Window Sdl2Window, SDL_SysWMinfo* info) => s_getWindowWMInfo(Sdl2Window, info);
    }
}
