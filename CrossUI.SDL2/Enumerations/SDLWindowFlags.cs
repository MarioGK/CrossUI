using System;

namespace CrossUI.SDL2.Enumerations
{
    [Flags]
    public enum SDLWindowFlags : uint
    {
        /// <summary>
        /// fullscreen Sdl2Window.
        /// </summary>
        Fullscreen = 0x00000001,
        /// <summary>
        /// Sdl2Window usable with OpenGL context.
        /// </summary>
        OpenGL = 0x00000002,
        /// <summary>
        /// Sdl2Window is visible.
        /// </summary>
        Shown = 0x00000004,
        /// <summary>
        /// Sdl2Window is not visible.
        /// </summary>
        Hidden = 0x00000008,
        /// <summary>
        /// no Sdl2Window decoration.
        /// </summary>
        Borderless = 0x00000010,
        /// <summary>
        /// Sdl2Window can be resized.
        /// </summary>
        Resizable = 0x00000020,
        /// <summary>
        /// Sdl2Window is minimized.
        /// </summary>
        Minimized = 0x00000040,
        /// <summary>
        /// Sdl2Window is maximized.
        /// </summary>
        Maximized = 0x00000080,
        /// <summary>
        /// Sdl2Window has grabbed input focus.
        /// </summary>
        InputGrabbed = 0x00000100,
        /// <summary>
        /// Sdl2Window has input focus.
        /// </summary>
        InputFocus = 0x00000200,
        /// <summary>
        /// Sdl2Window has mouse focus.
        /// </summary>
        MouseFocus = 0x00000400,
        FullScreenDesktop = (Fullscreen | 0x00001000),
        /// <summary>
        /// Sdl2Window not created by SDL.
        /// </summary>
        Foreign = 0x00000800,
        /// <summary>
        /// Sdl2Window should be created in high-DPI mode if supported.
        /// </summary>
        AllowHighDpi = 0x00002000,
        /// <summary>
        /// Sdl2Window has mouse captured (unrelated to InputGrabbed).
        /// </summary>
        MouseCapture = 0x00004000,
        /// <summary>
        /// Sdl2Window should always be above others.
        /// </summary>
        AlwaysOnTop = 0x00008000,
        /// <summary>
        /// Sdl2Window should not be added to the taskbar.
        /// </summary>
        SkipTaskbar = 0x00010000,
        /// <summary>
        /// Sdl2Window should be treated as a utility Sdl2Window.
        /// </summary>
        Utility = 0x00020000,
        /// <summary>
        /// Sdl2Window should be treated as a tooltip.
        /// </summary>
        Tooltip = 0x00040000,
        /// <summary>
        /// Sdl2Window should be treated as a popup menu.
        /// </summary>
        PopupMenu = 0x00080000
    }
}