
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        private static Font font = new Font("arial.ttf");
        public string DisplayText { get; set; }

        public Color Background { get; set; }
        public Color Foreground { get; set; }
        
        public Button(string id, Vector2i pos) : base(id, pos)
        {
            Background = new Color(255,0,0);
            Foreground = new Color(0,0,0);
        }

        internal override void Draw()
        {
            
        }
    }
}