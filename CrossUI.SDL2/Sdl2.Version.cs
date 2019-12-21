using System.Runtime.InteropServices;
using CrossUI.SDL2.Objects;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetVersion_t(SDL_version* version);
        private static SDL_GetVersion_t s_getVersion = LoadFunction<SDL_GetVersion_t>("SDL_GetVersion");
        public static void SDL_GetVersion(SDL_version* version) => s_getVersion(version);
    }
}
