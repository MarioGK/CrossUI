using CrossUI.SFML.Graphics;

namespace CrossUI.Managers
{
    public static class FontManager
    {
        static FontManager()
        {
            SegoeUI = new Font("Fonts\\Segoe UI.ttf");
            Roboto = new Font("Fonts\\Roboto-Regular.ttf");
            MaterialDesignIcons = new Font("Fonts\\MaterialDesignIcons.ttf");

            CurrentFont = Roboto;
        }

        public static Font CurrentFont { get; set; }
        public static Font SegoeUI { get; set; }
        public static Font Roboto { get; set; }
        public static Font MaterialDesignIcons { get; set; }
    }
}