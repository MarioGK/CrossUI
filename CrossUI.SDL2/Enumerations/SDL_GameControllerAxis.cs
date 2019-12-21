namespace CrossUI.SDL2.Enumerations
{
    /// <summary>
    /// The list of axes available from a controller.
    /// Thumbstick axis values range from SDL_Joystick_AXIS_MIN to SDL_Joystick_AXIS_MAX,
    /// and are centered within ~8000 of zero, though advanced UI will allow users to set
    /// or autodetect the dead zone, which varies between controllers.
    /// Trigger axis values range from 0 to SDL_Joystick_AXIS_MAX.
    /// </summary>
    public enum SDL_GameControllerAxis : byte
    {
        Invalid = unchecked((byte)-1),
        LeftX = 0,
        LeftY,
        RightX,
        RightY,
        TriggerLeft,
        TriggerRight,
        Max,
    }
}