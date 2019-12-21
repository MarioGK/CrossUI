using System.Collections.Generic;
using System.Numerics;
using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Events
{
    public interface IInputSnapshot
    {
        IReadOnlyList<KeyEvent> KeyEvents { get; }
        IReadOnlyList<MouseEvent> MouseEvents { get; }
        IReadOnlyList<char> KeyCharPresses { get; }
        bool IsMouseDown(MouseButton button);
        Vector2 MousePosition { get; }
        float WheelDelta { get; }
    }
}