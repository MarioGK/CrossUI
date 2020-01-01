using SFML.Graphics;

namespace CrossUI.Objects.Theme
{
    public class ThemeConfiguration
    {
        public Color ButtonColor { get; set; }
        public Color ButtonHoverColor { get; set; }
        public Color ButtonForeground { get; set; }
        
        public WindowTheme WindowTheme { get; set; } = new WindowTheme();
    }
}