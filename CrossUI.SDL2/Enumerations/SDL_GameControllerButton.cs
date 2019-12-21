namespace CrossUI.SDL2.Enumerations
{
    /// <summary>
    /// The list of buttons available from a controller.
    /// </summary>
    public enum SDL_GameControllerButton : byte
    {
        Invalid = unchecked((byte)-1),
        A = 0,
        B,
        X,
        Y,
        Back,
        Guide,
        Start,
        LeftStick,
        RightStick,
        LeftShoulder,
        RightShoulder,
        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight,
        Max
    }
}