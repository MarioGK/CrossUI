﻿using System.Runtime.InteropServices;

namespace CrossUI.SDL2
{
    public static unsafe partial class SDL
    {
        public const int SDL_QUERY = -1;
        public const int SDL_DISABLE = 0;
        public const int SDL_ENABLE = 1;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_ShowCursor_t(int toggle);
        private static SDL_ShowCursor_t s_sdl_showCursor = LoadFunction<SDL_ShowCursor_t>("SDL_ShowCursor");
        /// <summary>
        /// Toggle whether or not the cursor should be shown.
        /// </summary>
        public static int SDL_ShowCursor(int toggle) => s_sdl_showCursor(toggle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_WarpMouseInWindow_t(SDL_Window window, int x, int y);
        private static SDL_WarpMouseInWindow_t s_sdl_warpMouseInWindow = LoadFunction<SDL_WarpMouseInWindow_t>("SDL_WarpMouseInWindow");
        /// <summary>
        /// Move mouse position to the given position in the window.
        /// </summary>
        public static void SDL_WarpMouseInWindow(SDL_Window window, int x, int y) => s_sdl_warpMouseInWindow(window, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRelativeMouseMode_t(bool enabled);
        private static SDL_SetRelativeMouseMode_t s_sdl_setRelativeMouseMode = LoadFunction<SDL_SetRelativeMouseMode_t>("SDL_SetRelativeMouseMode");
        /// <summary>
        /// Enable/disable relative mouse mode.
        /// If enabled mouse cursor will be hidden and only relative
        /// mouse motion events will be delivered, mouse position will not change.
        /// </summary>
        /// <returns>
        /// Returns 0 on success or a negative error code on failure; call SDL_GetError() for more information.
        /// If relative mode is not supported this returns -1.
        /// </returns>
        public static int SDL_SetRelativeMouseMode(bool enabled) => s_sdl_setRelativeMouseMode(enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_CaptureMouse_t(bool enabled);
        private static SDL_CaptureMouse_t s_sdl_captureMouse = LoadFunction<SDL_CaptureMouse_t>("SDL_CaptureMouse");
        /// <summary>
        /// Enable/disable capture mouse.
        /// If enabled mouse will also be tracked outside the window.
        /// </summary>
        /// <returns>
        /// Returns 0 on success or -1 if not supported; call SDL_GetError() for more information.
        /// </returns>
        public static int SDL_CaptureMouse(bool enabled) => s_sdl_captureMouse(enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowGrab_t(SDL_Window window, bool grabbed);
        private static SDL_SetWindowGrab_t s_sdl_setWindowGrabbed = LoadFunction<SDL_SetWindowGrab_t>("SDL_SetWindowGrab");
        /// <summary>
        /// Enable/disable window grab mouse.
        /// If enabled mouse will be contained inside of window.
        /// </summary>
        public static void SDL_SetWindowGrab(SDL_Window window, bool grabbed) => s_sdl_setWindowGrabbed(window, grabbed);
    }
}