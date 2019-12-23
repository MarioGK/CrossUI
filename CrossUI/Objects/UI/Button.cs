
using SFML.Graphics;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        public string DisplayText { get; set; }

        public Color Background { get; set; }
        public Color Foreground { get; set; }
        
        public Button(string id, RectangleShape rect) : base(id)
        {
            Background = new Color(255,0,0);
            Foreground = new Color(0,0,0);
        }

        internal override void Draw()
        {
            
        }
    }
}