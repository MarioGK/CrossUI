using System;
using System.Runtime.InteropServices;
using CrossUI.SDL2.Enumerations;
using CrossUI.SDL2.Objects;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        /// <summary>
        /// A special sentinel value indicating that a newly-created window should be centered in the screen.
        /// </summary>
        public const int SDL_WINDOWPOS_CENTERED = 0x2FFF0000;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindow_t(string title, int x, int y, int w, int h, SDL_WindowFlags flags);
        private static SDL_CreateWindow_t s_sdl_createWindow = LoadFunction<SDL_CreateWindow_t>("SDL_CreateWindow");
        public static SDL_Window SDL_CreateWindow(string title, int x, int y, int w, int h, SDL_WindowFlags flags) => s_sdl_createWindow(title, x, y, w, h, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindowFrom_t(IntPtr data);
        private static SDL_CreateWindowFrom_t s_sdl_createWindowFrom = LoadFunction<SDL_CreateWindowFrom_t>("SDL_CreateWindowFrom");
        public static SDL_Window SDL_CreateWindowFrom(IntPtr data) => s_sdl_createWindowFrom(data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyWindow_t(SDL_Window SDL2Window);
        private static SDL_DestroyWindow_t s_sdl_destroyWindow = LoadFunction<SDL_DestroyWindow_t>("SDL_DestroyWindow");
        public static void SDL_DestroyWindow(SDL_Window Sdl2Window) => s_sdl_destroyWindow(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowSize_t(SDL_Window SDL2Window, int* w, int* h);
        private static SDL_GetWindowSize_t s_getWindowSize = LoadFunction<SDL_GetWindowSize_t>("SDL_GetWindowSize");
        public static void SDL_GetWindowSize(SDL_Window Sdl2Window, int* w, int* h) => s_getWindowSize(Sdl2Window, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowPosition_t(SDL_Window SDL2Window, int* x, int* y);
        private static SDL_GetWindowPosition_t s_getWindowPosition = LoadFunction<SDL_GetWindowPosition_t>("SDL_GetWindowPosition");
        public static void SDL_GetWindowPosition(SDL_Window Sdl2Window, int* x, int* y) => s_getWindowPosition(Sdl2Window, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowPosition_t(SDL_Window SDL2Window, int x, int y);
        private static SDL_SetWindowPosition_t s_setWindowPosition = LoadFunction<SDL_SetWindowPosition_t>("SDL_SetWindowPosition");
        public static void SDL_SetWindowPosition(SDL_Window Sdl2Window, int x, int y) => s_setWindowPosition(Sdl2Window, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowSize_t(SDL_Window SDL2Window, int w, int h);
        private static SDL_SetWindowSize_t s_setWindowSize = LoadFunction<SDL_SetWindowSize_t>("SDL_SetWindowSize");
        public static void SDL_SetWindowSize(SDL_Window Sdl2Window, int w, int h) => s_setWindowSize(Sdl2Window, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate string SDL_GetWindowTitle_t(SDL_Window SDL2Window);
        private static SDL_GetWindowTitle_t s_getWindowTitle = LoadFunction<SDL_GetWindowTitle_t>("SDL_GetWindowTitle");
        public static string SDL_GetWindowTitle(SDL_Window Sdl2Window) => s_getWindowTitle(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowTitle_t(SDL_Window SDL2Window, string title);
        private static SDL_SetWindowTitle_t s_setWindowTitle = LoadFunction<SDL_SetWindowTitle_t>("SDL_SetWindowTitle");
        public static void SDL_SetWindowTitle(SDL_Window Sdl2Window, string title) => s_setWindowTitle(Sdl2Window, title);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_WindowFlags SDL_GetWindowFlags_t(SDL_Window SDL2Window);
        private static SDL_GetWindowFlags_t s_getWindowFlags = LoadFunction<SDL_GetWindowFlags_t>("SDL_GetWindowFlags");
        public static SDL_WindowFlags SDL_GetWindowFlags(SDL_Window Sdl2Window) => s_getWindowFlags(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowBordered_t(SDL_Window SDL2Window, uint bordered);
        private static SDL_SetWindowBordered_t s_setWindowBordered = LoadFunction<SDL_SetWindowBordered_t>("SDL_SetWindowBordered");
        public static void SDL_SetWindowBordered(SDL_Window Sdl2Window, uint bordered) => s_setWindowBordered(Sdl2Window, bordered);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MaximizeWindow_t(SDL_Window SDL2Window);
        private static SDL_MaximizeWindow_t s_maximizeWindow = LoadFunction<SDL_MaximizeWindow_t>("SDL_MaximizeWindow");
        public static void SDL_MaximizeWindow(SDL_Window Sdl2Window) => s_maximizeWindow(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MinimizeWindow_t(SDL_Window SDL2Window);
        private static SDL_MinimizeWindow_t s_minimizeWindow = LoadFunction<SDL_MinimizeWindow_t>("SDL_MinimizeWindow");
        public static void SDL_MinimizeWindow(SDL_Window Sdl2Window) => s_minimizeWindow(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowFullscreen_t(SDL_Window Sdl2Window, SDL_FullscreenMode mode);
        private static SDL_SetWindowFullscreen_t s_setWindowFullscreen = LoadFunction<SDL_SetWindowFullscreen_t>("SDL_SetWindowFullscreen");
        public static int SDL_SetWindowFullscreen(SDL_Window Sdl2Window, SDL_FullscreenMode mode) => s_setWindowFullscreen(Sdl2Window, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ShowWindow_t(SDL_Window SDL2Window);
        private static SDL_ShowWindow_t s_showWindow = LoadFunction<SDL_ShowWindow_t>("SDL_ShowWindow");
        public static void SDL_ShowWindow(SDL_Window Sdl2Window) => s_showWindow(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_HideWindow_t(SDL_Window SDL2Window);
        private static SDL_HideWindow_t s_hideWindow = LoadFunction<SDL_HideWindow_t>("SDL_HideWindow");
        public static void SDL_HideWindow(SDL_Window Sdl2Window) => s_hideWindow(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_GetWindowID_t(SDL_Window SDL2Window);
        private static SDL_GetWindowID_t s_getWindowID = LoadFunction<SDL_GetWindowID_t>("SDL_GetWindowID");
        public static uint SDL_GetWindowID(SDL_Window Sdl2Window) => s_getWindowID(Sdl2Window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowOpacity_t(SDL_Window window, float opacity);
        private static SDL_SetWindowOpacity_t s_setWindowOpacity = LoadFunction<SDL_SetWindowOpacity_t>("SDL_SetWindowOpacity");
        public static int SDL_SetWindowOpacity(SDL_Window Sdl2Window, float opacity) => s_setWindowOpacity(Sdl2Window, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowOpacity_t(SDL_Window window, float* opacity);
        private static SDL_GetWindowOpacity_t s_getWindowOpacity = LoadFunction<SDL_GetWindowOpacity_t>("SDL_GetWindowOpacity");
        public static int SDL_GetWindowOpacity(SDL_Window Sdl2Window, float* opacity) => s_getWindowOpacity(Sdl2Window, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowResizable_t(SDL_Window window, uint resizable);
        private static SDL_SetWindowResizable_t s_setWindowResizable = LoadFunction<SDL_SetWindowResizable_t>("SDL_SetWindowResizable");
        public static void SDL_SetWindowResizable(SDL_Window window, uint resizable) => s_setWindowResizable(window, resizable);
    }
}
