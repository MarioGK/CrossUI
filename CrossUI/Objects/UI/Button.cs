using SDL2;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        public string DisplayText { get; set; }

        public Color Background { get; set; }
        public Color Foreground { get; set; }
        
        public Button(string id, SDL.SDL_Rect rect) : base(id)
        {
            Background = new Color(255,0,0);
            Foreground = new Color(0,0,0);
        }

        internal override void Draw()
        {
            
        }
    }
}