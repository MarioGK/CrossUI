using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_Init_t(SDLInitFlags flags);
        private static SDL_Init_t s_sdl_init = LoadFunction<SDL_Init_t>("SDL_Init");

        public static int Init(SDLInitFlags flags) => s_sdl_init(flags);
    }
}
