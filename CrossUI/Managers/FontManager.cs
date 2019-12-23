using SFML.Graphics;

namespace CrossUI.Managers
{
    public static class FontManager
    {
        public static Font Font { get; set; }

        public static void Initialize()
        {
            Font = new Font("segoeui.ttf");
        }
    }
}