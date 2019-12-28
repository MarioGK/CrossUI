using CrossUI.Objects;
using SFML.Graphics;

namespace CrossUI.Managers
{
    public static class ThemeManager
    {
        public static Theme CurrentTheme { get; set; }

        public static Theme MaterialTheme = new Theme
        {
            ButtonColor = Color.Blue,
            ButtonForeground = Color.White,
            ButtonHoverColor = Color.Black
        };

        public static void Initialize()
        {
            if (Initialized)
            {
                return;
            }

            Initialized = true;
            CurrentTheme = MaterialTheme;
        }

        public static bool Initialized { get; set; }
    }
}