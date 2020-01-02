using CrossUI.Objects;
using CrossUI.Objects.Theme;
using CrossUI.SFML.Graphics;

namespace CrossUI.Managers
{
    public static class ThemeManager
    {
        public static ThemeConfiguration CurrentThemeConfiguration { get; set; }

        public static ThemeConfiguration MaterialThemeConfiguration = new ThemeConfiguration
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
            CurrentThemeConfiguration = MaterialThemeConfiguration;
        }

        public static bool Initialized { get; set; }
    }
}