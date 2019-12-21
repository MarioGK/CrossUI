namespace CrossUI.SDL2.Enumerations
{
    public enum SDL_WindowEventID : byte
    {
        /// <summary>
        /// Never used.
        /// </summary>
        None,
        /// <summary>
        /// Sdl2Window has been shown.
        /// </summary>
        Shown,
        /// <summary>
        /// Sdl2Window has been hidden.
        /// </summary>
        Hidden,
        /// <summary>
        /// Sdl2Window has been exposed and should be redrawn.
        /// </summary>
        Exposed,
        /// <summary>
        /// Sdl2Window has been moved to data1, data2.
        /// </summary>
        Moved,
        /// <summary>
        /// Sdl2Window has been resized to data1xdata2.
        /// </summary>
        Resized,
        /// <summary>
        /// The Sdl2Window size has changed, either as a result of an API call or through the system or user changing the Sdl2Window size.
        /// </summary>
        SizeChanged,
        /// <summary>
        /// Sdl2Window has been minimized.
        /// </summary>
        Minimized,
        /// <summary>
        /// Sdl2Window has been maximized.
        /// </summary>
        Maximized,
        /// <summary>
        /// Sdl2Window has been restored to normal size and position.
        /// </summary>
        Restored,
        /// <summary>
        /// Sdl2Window has gained mouse focus.
        /// </summary>
        Enter,
        /// <summary>
        /// Sdl2Window has lost mouse focus.
        /// </summary>
        Leave,
        /// <summary>
        /// Sdl2Window has gained keyboard focus.
        /// </summary>
        FocusGained,
        /// <summary>
        /// Sdl2Window has lost keyboard focus
        /// </summary>
        FocusLost,
        /// <summary>
        /// The Sdl2Window manager requests that the Sdl2Window be closed.
        /// </summary>
        Close,
        /// <summary>
        /// Sdl2Window is being offered a focus (should SetWindowInputFocus() on itself or a subwindow, or ignore).
        /// </summary>
        TakeFocus,
        /// <summary>
        /// Sdl2Window had a hit test that wasn't SDL_HITTEST_NORMAL.
        /// </summary>
        HitTest
    }
}