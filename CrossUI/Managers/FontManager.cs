using SFML.Graphics;

namespace CrossUI.Managers
{
    public static class FontManager
    {
        public static Font CurrentFont { get; set; }
        public static Font SegoeUI { get; set; }
        public static Font Roboto { get; set; }
        public static Font MaterialDesignIcons { get; set; }

        public static bool Initialized;

        public static void Initialize()
        {
            if (Initialized)
            {
                return;
            }

            Initialized = true;
            
            SegoeUI = new Font("Fonts\\Segoe UI.ttf");
            Roboto = new Font("Fonts\\Roboto-Regular.ttf");
            MaterialDesignIcons = new Font("Fonts\\MaterialDesignIcons.ttf");

            CurrentFont = Roboto;
        }
    }
}