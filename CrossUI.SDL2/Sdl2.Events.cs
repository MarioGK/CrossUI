using System.Runtime.InteropServices;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int SDL_EventFilter(void* userdata, SDL_Event* @event);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_PumpEvents_t();
        private static SDL_PumpEvents_t s_sdl_pumpEvents = LoadFunction<SDL_PumpEvents_t>("SDL_PumpEvents");
        public static void SDL_PumpEvents() => s_sdl_pumpEvents();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_PollEvent_t(SDL_Event* @event);
        private static SDL_PollEvent_t s_sdl_pollEvent = LoadFunction<SDL_PollEvent_t>("SDL_PollEvent");
        public static int SDL_PollEvent(SDL_Event* @event) => s_sdl_pollEvent(@event);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_AddEventWatch_t(SDL_EventFilter filter, void* userdata);
        private static SDL_AddEventWatch_t s_sdl_addEventWatch = LoadFunction<SDL_AddEventWatch_t>("SDL_AddEventWatch");
        public static void SDL_AddEventWatch(SDL_EventFilter filter, void* userdata) => s_sdl_addEventWatch(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetEventFilter_t(SDL_EventFilter filter, void* userdata);
        private static SDL_SetEventFilter_t s_sdl_setEventFilter = LoadFunction<SDL_SetEventFilter_t>("SDL_SetEventFilter");
        public static void SDL_SetEventFilter(SDL_EventFilter filter, void* userdata) => s_sdl_setEventFilter(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FilterEvents_t(SDL_EventFilter filter, void* userdata);
        private static SDL_FilterEvents_t s_sdl_filterEvents = LoadFunction<SDL_FilterEvents_t>("SDL_FilterEvents");
        public static void SDL_FilterEvents(SDL_EventFilter filter, void* userdata) => s_sdl_filterEvents(filter, userdata);
    }
}
