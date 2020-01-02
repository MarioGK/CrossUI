using CrossUI.Objects.Theme;
using CrossUI.SFML.Graphics;

namespace CrossUI.Managers
{
    public static class ThemeManager
    {
        static ThemeManager()
        {
            CurrentThemeConfiguration = MaterialThemeConfiguration;
        }

         public static ThemeConfiguration CurrentThemeConfiguration { get; set; }

        public static ThemeConfiguration MaterialThemeConfiguration = new ThemeConfiguration
        {
            ButtonColor = Color.Blue,
            ButtonForeground = Color.White,
            ButtonHoverColor = Color.Black
        };
    }
}