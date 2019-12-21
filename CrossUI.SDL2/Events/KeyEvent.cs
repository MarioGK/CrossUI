using CrossUI.SDL2.Enumerations;

namespace CrossUI.SDL2.Events
{
    public struct KeyEvent
    {
        public Key Key { get; }
        public bool Down { get; }
        public ModifierKeys Modifiers { get; }
        public KeyEvent(Key key, bool down, ModifierKeys modifiers)
        {
            Key = key;
            Down = down;
            Modifiers = modifiers;
        }

        public override string ToString() => $"{Key} {(Down ? "Down" : "Up")} [{Modifiers}]";
    }
}